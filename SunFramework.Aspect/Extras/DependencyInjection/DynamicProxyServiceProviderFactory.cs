using System;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.Extensions.DependencyInjection
{
    public class DynamicProxyServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
    {
        public IServiceCollection CreateBuilder(IServiceCollection services)
        {
            return services;
        }

        public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
        {
            return containerBuilder.BuildDynamicProxyProvider();
        }
    }
}
