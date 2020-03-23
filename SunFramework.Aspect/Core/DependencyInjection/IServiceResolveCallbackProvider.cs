using System.Collections.Generic;

namespace SunFramework.Aspect.DependencyInjection
{
    internal interface IServiceResolveCallbackProvider
    {
        IServiceResolveCallback[] ServiceResolveCallbacks { get; }
    }
}