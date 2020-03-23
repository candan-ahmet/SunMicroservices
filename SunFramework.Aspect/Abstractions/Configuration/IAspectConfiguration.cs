using SunFramework.Aspect.DynamicProxy;
using SunFramework.Aspect.DependencyInjection;

namespace SunFramework.Aspect.Configuration
{
    [NonAspect]
    public interface IAspectConfiguration
    {
        AspectValidationHandlerCollection ValidationHandlers { get; }

        InterceptorCollection Interceptors { get; }

        NonAspectPredicateCollection NonAspectPredicates { get; }

        bool ThrowAspectException { get; set; }
    }
}