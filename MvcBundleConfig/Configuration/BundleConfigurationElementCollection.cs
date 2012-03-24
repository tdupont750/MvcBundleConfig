using System;
using System.Configuration;

namespace MvcBundleConfig.Configuration
{
    [ConfigurationCollection(typeof(BundleConfigurationElement))]
    public class BundleConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BundleConfigurationElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((BundleConfigurationElement)element).BundlePath;
        }

        public BundleConfigurationElement this[int index]
        {
            get { return (BundleConfigurationElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }
    }
}