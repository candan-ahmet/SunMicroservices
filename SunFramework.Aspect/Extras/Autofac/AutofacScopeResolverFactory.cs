using SunFramework.Aspect.DynamicProxy;
using SunFramework.Aspect.DependencyInjection;
using Autofac;

namespace SunFramework.Aspect.Extensions.Autofac
{
    [NonAspect]
    internal class AutofacScopeResolverFactory : IScopeResolverFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacScopeResolverFactory(ILifetimeScope lifetimeScope)
        {
            this._lifetimeScope = lifetimeScope;
        }

        public IServiceResolver CreateScope()
        {
            return new AutofacServiceResolver(_lifetimeScope.BeginLifetimeScope());
        }
    }
}