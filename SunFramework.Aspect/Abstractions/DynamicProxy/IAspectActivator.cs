using System.Threading.Tasks;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectActivator
    {
        TResult Invoke<TResult>(AspectActivatorContext activatorContext);

        Task<TResult> InvokeTask<TResult>(AspectActivatorContext activatorContext);

        ValueTask<TResult> InvokeValueTask<TResult>(AspectActivatorContext activatorContext);
    }
}