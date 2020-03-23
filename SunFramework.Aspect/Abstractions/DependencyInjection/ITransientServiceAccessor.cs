using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect]
    public interface ITransientServiceAccessor<T> where T : class
    {
        T Value { get; }
    }
}