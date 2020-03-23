using System;

namespace SunFramework.Aspect.DynamicProxy
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AsyncAspectAttribute : Attribute
    {
    }
}