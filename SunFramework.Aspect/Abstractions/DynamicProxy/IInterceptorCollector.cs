using System.Collections.Generic;
using System.Reflection;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IInterceptorCollector
    {
        IEnumerable<IInterceptor> Collect(MethodInfo serviceMethod, MethodInfo implementationMethod);
    }
}
