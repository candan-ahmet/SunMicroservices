using System;
using System.Collections.Generic;
using SunFramework.Aspect.Configuration;
using SunFramework.Aspect.DependencyInjection;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public sealed class ProxyGeneratorBuilder
    {
        private readonly IAspectConfiguration _configuration;
        private readonly IServiceContext _serviceContext;

        public ProxyGeneratorBuilder()
        {
            _configuration = new AspectConfiguration();
            _serviceContext = new ServiceContext(_configuration);
        }

        public ProxyGeneratorBuilder Configure(Action<IAspectConfiguration> options = null)
        {
            options?.Invoke(_configuration);
            return this;
        }

        public ProxyGeneratorBuilder ConfigureService(Action<IServiceContext> options = null)
        {
            options?.Invoke(_serviceContext);
            return this;
        }

        public IProxyGenerator Build()
        {
            var serviceResolver = _serviceContext.Build();
            return new DisposedProxyGenerator(serviceResolver);
        }
    }
}