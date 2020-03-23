using System;

namespace SunFramework.Aspect.DynamicProxy
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class NonAspectAttribute : Attribute
    {
    }
}
