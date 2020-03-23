namespace SunFramework.Aspect.Extensions.Configuration
{
    public interface IConfigurationMetadataProvider
    {
        string[] Sections { get; }
        
        string Key { get; }
        
        ConfigurationBindType Type { get; }
    }
}