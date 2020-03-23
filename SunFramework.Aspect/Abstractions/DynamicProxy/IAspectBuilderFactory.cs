namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectBuilderFactory
    {
        IAspectBuilder Create(AspectContext context);
    }
}
