using System.Configuration;

namespace MvcBundleConfig.Configuration
{
    public class BundleFileConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("filePath", IsRequired = true, IsKey = true)]
        public string FilePath
        {
            get { return (string)this["filePath"]; }
            set { this["filePath"] = value; }
        }

        [ConfigurationProperty("throwIfNotExist", DefaultValue = true, IsRequired = false)]
        public bool ThrowIfNotExist
        {
            get { return (bool)this["throwIfNotExist"]; }
            set { this["throwIfNotExist"] = value; }
        }
    }
}