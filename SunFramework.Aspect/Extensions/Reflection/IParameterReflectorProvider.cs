namespace SunFramework.Aspect.Extensions.Reflection
{
    public interface IParameterReflectorProvider
    {
        ParameterReflector[] ParameterReflectors { get; }
    }
}