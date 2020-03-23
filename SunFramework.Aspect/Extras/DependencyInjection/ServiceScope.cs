using System;
using SunFramework.Aspect.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.Extensions.DependencyInjection
{
    internal class ServiceScope : IServiceScope
    {
        private readonly IServiceResolver _serviceResolver;
        public IServiceProvider ServiceProvider => _serviceResolver;

        public ServiceScope(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        public void Dispose()
        {
            _serviceResolver.Dispose();
        }
    }
}
