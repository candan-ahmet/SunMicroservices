namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectContextFactory
    {
        AspectContext CreateContext(AspectActivatorContext activatorContext);

        void ReleaseContext(AspectContext aspectContext);
    }
}
