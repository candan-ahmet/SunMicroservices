using System.Reflection;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectValidator
    {
        bool Validate(MethodInfo method, bool isStrictValidation);
    }
}