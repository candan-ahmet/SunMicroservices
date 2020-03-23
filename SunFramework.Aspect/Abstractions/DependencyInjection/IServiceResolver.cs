using System;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect]
    public interface IServiceResolver : IServiceProvider, IDisposable
    {
        object Resolve(Type serviceType);
    }
}