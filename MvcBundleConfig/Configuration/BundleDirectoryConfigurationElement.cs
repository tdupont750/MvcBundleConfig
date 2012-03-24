using System.Configuration;

namespace MvcBundleConfig.Configuration
{
    public class BundleDirectoryConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("directoryPath", IsRequired = true, IsKey = true)]
        public string DirectoryPath
        {
            get { return (string)this["directoryPath"]; }
            set { this["directoryPath"] = value; }
        }

        [ConfigurationProperty("searchPattern", IsRequired = true)]
        public string SearchPattern
        {
            get { return (string)this["searchPattern"]; }
            set { this["searchPattern"] = value; }
        }

        [ConfigurationProperty("searchSubdirectories", DefaultValue = false, IsRequired = false)]
        public bool SearchSubdirectories
        {
            get { return (bool)this["searchSubdirectories"]; }
            set { this["searchSubdirectories"] = value; }
        }

        [ConfigurationProperty("throwIfNotExist", DefaultValue = true, IsRequired = false)]
        public bool ThrowIfNotExist
        {
            get { return (bool)this["throwIfNotExist"]; }
            set { this["throwIfNotExist"] = value; }
        }
    }
}