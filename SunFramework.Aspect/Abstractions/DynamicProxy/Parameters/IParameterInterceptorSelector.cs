using System.Reflection;

namespace SunFramework.Aspect.DynamicProxy.Parameters
{
    public interface IParameterInterceptorSelector
    {
        IParameterInterceptor[] Select(ParameterInfo parameter);
    }
}