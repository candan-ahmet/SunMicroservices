using System.Collections;
using System.Collections.Generic;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.DependencyInjection
{
    [NonAspect, NonCallback]
    public interface IManyEnumerable<out T> : IEnumerable<T>, IEnumerable
    {
    }
}