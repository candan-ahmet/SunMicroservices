namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectActivatorFactory
    {
        IAspectActivator Create();
    }
}