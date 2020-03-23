using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.Extensions.AspectScope
{
    [NonAspect]
    public interface IScopeInterceptor : IInterceptor
    {
        Scope Scope { get; set; }
    }
}