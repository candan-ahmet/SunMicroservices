using System.Reflection;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectValidationHandler
    {
        int Order { get; }

        bool Invoke(AspectValidationContext context, AspectValidationDelegate next);
    }
}
