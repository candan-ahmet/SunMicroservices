using System;
using System.Collections.Generic;
using SunFramework.Aspect.Configuration;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect]
    public interface IServiceContext : IEnumerable<ServiceDefinition>
    {
        ILifetimeServiceContext Singletons { get; }

        ILifetimeServiceContext Scopeds { get; }

        ILifetimeServiceContext Transients { get; }

        IAspectConfiguration Configuration { get; }

        int Count { get; }

        void Add(ServiceDefinition item);

        bool Contains(Type serviceType);
    }
}