using System;

namespace SunFramework.Aspect.DynamicProxy
{
    [NonAspect]
    public interface IAspectCachingProvider : IDisposable
    {
        IAspectCaching GetAspectCaching(string name);
    }
}