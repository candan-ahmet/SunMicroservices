using System;
using SunFramework.Aspect.DynamicProxy;
using SunFramework.Aspect.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.Extensions.DependencyInjection
{
    [NonAspect]
    public class ServiceContextProviderFactory : IServiceProviderFactory<IServiceContext>
    {
        public IServiceContext CreateBuilder(IServiceCollection services)
        {
            return services.ToServiceContext();
        }

        public IServiceProvider CreateServiceProvider(IServiceContext contextBuilder)
        {
            return contextBuilder.Build();
        }
    }
}