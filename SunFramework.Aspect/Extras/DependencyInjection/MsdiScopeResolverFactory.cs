using System;
using SunFramework.Aspect.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.Extensions.DependencyInjection
{
    internal class MsdiScopeResolverFactory : IScopeResolverFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MsdiScopeResolverFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IServiceResolver CreateScope()
        {
            return new MsdiServiceResolver(_serviceProvider.CreateScope().ServiceProvider);
        }
    }
}
