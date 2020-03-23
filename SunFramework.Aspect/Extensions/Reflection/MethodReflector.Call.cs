﻿using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using SunFramework.Aspect.Extensions.Reflection.Emit;
using SunFramework.Aspect.Extensions.Reflection.Internals;

namespace SunFramework.Aspect.Extensions.Reflection
{
    public partial class MethodReflector : MemberReflector<MethodInfo>
    {
        private class CallMethodReflector : MethodReflector
        {
            public CallMethodReflector(MethodInfo reflectionInfo)
               : base(reflectionInfo)
            {
            }

            protected override Func<object, object[], object> CreateInvoker()
            {
                DynamicMethod dynamicMethod = new DynamicMethod($"invoker_{_displayName}",
                typeof(object), new Type[] { typeof(object), typeof(object[]) }, _reflectionInfo.Module, true);

                ILGenerator ilGen = dynamicMethod.GetILGenerator();
                var parameterTypes = _reflectionInfo.GetParameterTypes();

                ilGen.EmitLoadArg(0);
                ilGen.EmitConvertFromObject(_reflectionInfo.DeclaringType);
                if (_reflectionInfo.DeclaringType.GetTypeInfo().IsValueType)
                {
                    var local = ilGen.DeclareLocal(_reflectionInfo.DeclaringType);
                    ilGen.Emit(OpCodes.Stloc, local);
                    ilGen.Emit(OpCodes.Ldloca, local);
                }

                if (parameterTypes.Length == 0)
                {
                    return CreateDelegate();
                }

                var refParameterCount = parameterTypes.Count(x => x.IsByRef);
                if (refParameterCount == 0)
                {
                    for (var i = 0; i < parameterTypes.Length; i++)
                    {
                        ilGen.EmitLoadArg(1);
                        ilGen.EmitInt(i);
                        ilGen.Emit(OpCodes.Ldelem_Ref);
                        ilGen.EmitConvertFromObject(parameterTypes[i]);
                    }
                    return CreateDelegate();
                }

                var indexedLocals = new IndexedLocalBuilder[refParameterCount];
                var index = 0;
                for (var i = 0; i < parameterTypes.Length; i++)
                {
                    ilGen.EmitLoadArg(1);
                    ilGen.EmitInt(i);
                    ilGen.Emit(OpCodes.Ldelem_Ref);
                    if (parameterTypes[i].IsByRef)
                    {
                        var defType = parameterTypes[i].GetElementType();
                        var indexedLocal = new IndexedLocalBuilder(ilGen.DeclareLocal(defType), i);
                        indexedLocals[index++] = indexedLocal;
                        ilGen.EmitConvertFromObject(defType);
                        ilGen.Emit(OpCodes.Stloc, indexedLocal.LocalBuilder);
                        ilGen.Emit(OpCodes.Ldloca, indexedLocal.LocalBuilder);
                    }
                    else
                    {
                        ilGen.EmitConvertFromObject(parameterTypes[i]);
                    }
                }

                return CreateDelegate(() =>
                {
                    for (var i = 0; i < indexedLocals.Length; i++)
                    {
                        ilGen.EmitLoadArg(1);
                        ilGen.EmitInt(indexedLocals[i].Index);
                        ilGen.Emit(OpCodes.Ldloc, indexedLocals[i].LocalBuilder);
                        ilGen.EmitConvertToObject(indexedLocals[i].LocalType);
                        ilGen.Emit(OpCodes.Stelem_Ref);
                    }
                });

                Func<object, object[], object> CreateDelegate(Action callback = null)
                {
                    ilGen.EmitCall(OpCodes.Call, _reflectionInfo, null);
                    callback?.Invoke();
                    if (_reflectionInfo.ReturnType == typeof(void)) ilGen.Emit(OpCodes.Ldnull);
                    else if (_reflectionInfo.ReturnType.GetTypeInfo().IsValueType)
                        ilGen.EmitConvertToObject(_reflectionInfo.ReturnType);
                    ilGen.Emit(OpCodes.Ret);
                    return (Func<object, object[], object>)dynamicMethod.CreateDelegate(typeof(Func<object, object[], object>));
                }
            }
        }
    }
}