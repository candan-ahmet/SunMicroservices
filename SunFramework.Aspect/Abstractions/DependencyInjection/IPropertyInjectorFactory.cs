using System;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect]
    public interface IPropertyInjectorFactory
    {
        IPropertyInjector Create(Type implementationType);
    }
}