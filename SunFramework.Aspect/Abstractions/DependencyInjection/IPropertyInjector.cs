using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect]
    public interface IPropertyInjector
    {
        void Invoke(object implementation);
    }
}
