using System;
using System.Reflection;

namespace SunFramework.Aspect.DependencyInjection
{
    public sealed class InstanceServiceDefinition : ServiceDefinition
    {
        public InstanceServiceDefinition(Type serviceType, object implementationInstance) : base(serviceType, Lifetime.Singleton)
        {
            ImplementationInstance = implementationInstance ?? throw new ArgumentNullException(nameof(implementationInstance));
        }

        public object ImplementationInstance { get; }
    }
}