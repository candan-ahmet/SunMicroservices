using System.Reflection;

namespace SunFramework.Aspect.Extensions.Reflection
{
    public partial class CustomAttributeReflector
    {
        internal static CustomAttributeReflector Create(CustomAttributeData customAttributeData)
        {
            return ReflectorCacheUtils<CustomAttributeData, CustomAttributeReflector>.GetOrAdd(customAttributeData, data => new CustomAttributeReflector(data));
        }
    }
}
