namespace SunFramework.Aspect.Extensions.Reflection
{
    public interface ICustomAttributeReflectorProvider
    {
        CustomAttributeReflector[] CustomAttributeReflectors { get; }
    }
}