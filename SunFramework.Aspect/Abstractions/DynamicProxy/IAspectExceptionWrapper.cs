using System;

namespace SunFramework.Aspect.DynamicProxy
{
    public interface IAspectExceptionWrapper
    {
        Exception Wrap(AspectContext aspectContext, Exception exception);
    }
}