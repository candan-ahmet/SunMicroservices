using System.Threading.Tasks;

namespace SunFramework.Aspect.DynamicProxy.Parameters
{
    [NonAspect]
    public interface IParameterInterceptor
    {
        Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next);
    }
}