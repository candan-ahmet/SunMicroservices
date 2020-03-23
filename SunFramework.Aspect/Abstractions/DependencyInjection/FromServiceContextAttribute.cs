using System;

namespace SunFramework.Aspect.DependencyInjection
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class FromServiceContextAttribute : Attribute
    {
        public FromServiceContextAttribute()
        {
        }
    }
}