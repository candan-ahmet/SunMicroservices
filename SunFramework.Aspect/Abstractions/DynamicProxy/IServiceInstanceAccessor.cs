namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IServiceInstanceAccessor
    {
        object ServiceInstance { get; }
    }

    [NonAspect]
    public interface IServiceInstanceAccessor<TService>
    {
        TService ServiceInstance { get; }
    }
}
