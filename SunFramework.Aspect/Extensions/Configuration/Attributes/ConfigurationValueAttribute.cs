using System;

namespace SunFramework.Aspect.Extensions.Configuration
{
    public class ConfigurationValueAttribute : ConfigurationMetadataAttribute
    {
        public override string Key { get; }

        public override ConfigurationBindType Type { get; } = ConfigurationBindType.Value;

        public override string[] Sections { get; }

        public ConfigurationValueAttribute(string key, params string[] sections)
        {
            Key = key;
            Sections = sections;
        }
    }
}