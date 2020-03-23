using System.Collections.Generic;
using System.Reflection;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IInterceptorSelector
    {
        IEnumerable<IInterceptor> Select(MethodInfo method);
    }
}