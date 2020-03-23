using System;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect, NonCallback]
    public interface IServiceResolveCallback
    {
        object Invoke(IServiceResolver resolver, object instance, ServiceDefinition service);
    }

    public sealed class NonCallback : Attribute
    {
    }
}