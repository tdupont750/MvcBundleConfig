using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using MvcBundleConfig.Configuration;
using MvcBundleConfig.Models;

namespace MvcBundleConfig
{
    public class BundleConfigurationManager
    {
        private static BundleConfigCollection _collection;

        public static BundleConfigCollection GetBundleConfigCollection()
        {
            if (_collection == null)
                throw new ApplicationException("BundleConfigCollection has not been initialized.");

            return _collection;
        }

        public static void Init(BundleConfigCollection collection = null)
        {
            if (collection == null)
            {
                BundleConfigurationSection config;

                try
                {
                    config = (BundleConfigurationSection)WebConfigurationManager.GetSection("bundleConfig");
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Can not find section <bundleConfig> in the configuration file", ex);
                }

                var cssBundles = CreateBundleConfigs(config.CssBundles);
                var jsBundles = CreateBundleConfigs(config.JsBundles);

                collection = new BundleConfigCollection
                {
                    IgnoreIfDebug = config.IgnoreIfDebug,
                    IgnoreIfLocal = config.IgnoreIfLocal,
                    CssBundles = cssBundles,
                    JsBundles = jsBundles
                };
            }

            _collection = collection;
        }

        private static IList<BundleConfig> CreateBundleConfigs(BundleConfigurationElementCollection bundles)
        {
            var result = new List<BundleConfig>();

            foreach (BundleConfigurationElement bundle in bundles)
            {
                var bundleConfig = new BundleConfig
                {
                    BundlePath = bundle.BundlePath,
                    Minify = bundle.Minify,
                    Directories = new List<BundleDirectory>(),
                    Files = new List<BundleFile>()
                };

                foreach (BundleDirectoryConfigurationElement directory in bundle.Directories)
                {
                    bundleConfig.Directories.Add(new BundleDirectory
                    {
                        DirectoryPath = directory.DirectoryPath,
                        SearchPattern = directory.SearchPattern,
                        SearchSubdirectories = directory.SearchSubdirectories,
                        ThrowIfNotExist = directory.ThrowIfNotExist
                    });
                }

                foreach (BundleFileConfigurationElement file in bundle.Files)
                {
                    bundleConfig.Files.Add(new BundleFile
                    {
                        FilePath = file.FilePath,
                        ThrowIfNotExist = file.ThrowIfNotExist
                    });
                }

                result.Add(bundleConfig);
            }

            return result;
        }

        public static bool Ignore(HttpContextBase httpContext)
        {
            var config = GetBundleConfigCollection();

            return (config.IgnoreIfDebug && httpContext.IsDebuggingEnabled)
                   || (config.IgnoreIfLocal && httpContext.Request.IsLocal);
        }
    }
}