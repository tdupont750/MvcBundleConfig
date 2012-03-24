using System;
using System.Configuration;

namespace MvcBundleConfig.Configuration
{
    [ConfigurationCollection(typeof(BundleDirectoryConfigurationElement))]
    public class BundleDirectoryConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BundleDirectoryConfigurationElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((BundleDirectoryConfigurationElement)element).DirectoryPath;
        }

        public BundleDirectoryConfigurationElement this[int index]
        {
            get { return (BundleDirectoryConfigurationElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }
    }
}