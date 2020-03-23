using System;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IProxyTypeGenerator
    {
        Type CreateInterfaceProxyType(Type serviceType);

        Type CreateInterfaceProxyType(Type serviceType, Type implementationType);

        Type CreateClassProxyType(Type serviceType, Type implementationType);
    }
}