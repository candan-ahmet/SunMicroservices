using System;

namespace SunFramework.Aspect.DynamicProxy
{
    public class AspectInvocationException : Exception
    {
        public AspectContext AspectContext { get; }

        public AspectInvocationException(AspectContext aspectContext, Exception innerException)
            : base($"Exception has been thrown by the aspect of an invocation. ---> {innerException?.Message}.", innerException)
        {
            AspectContext = aspectContext;
        }
    }
}