using System;
using SunFramework.Aspect.DependencyInjection;

namespace SunFramework.Aspect.Extensions.Configuration
{
    public static class ServiceContainerExtensions
    {
        public static IServiceContext AddConfigurationInject(this IServiceContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.AddType<IServiceResolveCallback, ConfigurationBindResolveCallback>(Lifetime.Singleton);
            return context;
        }
    }
}