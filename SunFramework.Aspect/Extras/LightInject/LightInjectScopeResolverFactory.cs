using System;
using System.Collections.Generic;
using System.Text;
using SunFramework.Aspect.DependencyInjection;
using SunFramework.Aspect.DynamicProxy;
using LightInject;

namespace SunFramework.Aspect.Extensions.LightInject
{
    [NonAspect]
    internal class LightInjectScopeResolverFactory : IScopeResolverFactory
    {
        private readonly IServiceContainer _container;

        public LightInjectScopeResolverFactory(IServiceContainer container)
        {
            _container = container;
        }

        public IServiceResolver CreateScope()
        {
            return new LightInjectServiceResolver(_container.BeginScope());
        }
    }
}
