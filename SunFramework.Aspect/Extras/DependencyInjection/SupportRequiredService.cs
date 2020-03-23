using System;
using SunFramework.Aspect.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.Extensions.DependencyInjection
{
    internal class SupportRequiredService : ISupportRequiredService
    {
        private readonly IServiceResolver _serviceResolver;

        public SupportRequiredService(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        public object GetRequiredService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            return _serviceResolver.ResolveRequired(serviceType);
        }
    }
}