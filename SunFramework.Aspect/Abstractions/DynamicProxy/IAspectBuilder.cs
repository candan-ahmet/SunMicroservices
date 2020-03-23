using System;
using System.Collections.Generic;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectBuilder
    {
        IEnumerable<Func<AspectDelegate, AspectDelegate>> Delegates { get; }

        AspectDelegate Build();
    }
}
