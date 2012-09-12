using System.Configuration;

namespace MvcBundleConfig.Configuration
{
    public class BundleConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("bundlePath", IsRequired = true, IsKey = true)]
        public string BundlePath
        {
            get { return (string)this["bundlePath"]; }
            set { this["bundlePath"] = value; }
        }

        [ConfigurationProperty("cdnPath", IsRequired = false)]
        public string CdnPath
        {
            get { return (string)this["cdnPath"]; }
            set { this["cdnPath"] = value; }
        }

        [ConfigurationProperty("minify", DefaultValue = true, IsRequired = false)]
        public bool Minify
        {
            get { return (bool)this["minify"]; }
            set { this["minify"] = value; }
        }

        [ConfigurationProperty("files", IsDefaultCollection = false, IsRequired = false)]
        public BundleFileConfigurationElementCollection Files
        {
            get { return base["files"] as BundleFileConfigurationElementCollection; }
        }

        [ConfigurationProperty("directories", IsDefaultCollection = false, IsRequired = false)]
        public BundleDirectoryConfigurationElementCollection Directories
        {
            get { return base["directories"] as BundleDirectoryConfigurationElementCollection; }
        }
    }
}