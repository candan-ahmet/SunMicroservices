using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect]
    public interface IScopeResolverFactory
    {
        IServiceResolver CreateScope();
    }
}