using System;
using System.Web;
using System.Web.Configuration;

namespace MvcBundleConfig.Configuration
{
    public class BundleConfigurationManager
    {
        private static BundleConfigurationSection _config;

        public static BundleConfigurationSection GetBundleConfiguration()
        {
            if (_config == null)
            {
                try
                {
                    _config = (BundleConfigurationSection)WebConfigurationManager.GetSection("bundleConfig");
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Can not find section <bundleConfig> in the configuration file", ex);
                }
            }

            return _config;
        }

        public static bool Ignore(HttpContextBase httpContext)
        {
            var config = GetBundleConfiguration();

            return (config.IgnoreIfDebug && httpContext.IsDebuggingEnabled)
                   || (config.IgnoreIfLocal && httpContext.Request.IsLocal);
        }
    }
}