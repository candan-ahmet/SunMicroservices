using System;
using SunFramework.Aspect.Configuration;

namespace SunFramework.Aspect.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static IServiceContext Configure(this IServiceContext serviceContext, Action<IAspectConfiguration> configure)
        {
            if (serviceContext == null)
            {
                throw new ArgumentNullException(nameof(serviceContext));
            }
            configure?.Invoke(serviceContext.Configuration);
            return serviceContext;
        }
    }
}