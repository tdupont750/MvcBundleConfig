using System.Configuration;

namespace MvcBundleConfig.Configuration
{
    public class BundleConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("ignoreIfDebug", DefaultValue = true, IsRequired = false)]
        public bool IgnoreIfDebug
        {
            get { return (bool)this["ignoreIfDebug"]; }
            set { this["ignoreIfDebug"] = value; }
        }

        [ConfigurationProperty("ignoreIfLocal", DefaultValue = true, IsRequired = false)]
        public bool IgnoreIfLocal
        {
            get { return (bool)this["ignoreIfLocal"]; }
            set { this["ignoreIfLocal"] = value; }
        }

        [ConfigurationProperty("jsBundles", IsDefaultCollection = false)]
        public BundleConfigurationElementCollection JsBundles
        {
            get { return base["jsBundles"] as BundleConfigurationElementCollection; }
        }

        [ConfigurationProperty("cssBundles", IsDefaultCollection = false)]
        public BundleConfigurationElementCollection CssBundles
        {
            get { return base["cssBundles"] as BundleConfigurationElementCollection; }
        }
    }
}