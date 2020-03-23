namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectValidatorBuilder
    {
        IAspectValidator Build();
    }
}
