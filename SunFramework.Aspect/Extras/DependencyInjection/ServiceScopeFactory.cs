using SunFramework.Aspect.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.Extensions.DependencyInjection
{
    internal class ServiceScopeFactory : IServiceScopeFactory
    {
        private readonly IServiceResolver _serviceResolver;

        public ServiceScopeFactory(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        public IServiceScope CreateScope()
        {
            return new ServiceScope(_serviceResolver.CreateScope());
        }
    }
}
