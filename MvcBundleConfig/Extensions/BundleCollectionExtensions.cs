using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using MvcBundleConfig;
using MvcBundleConfig.Configuration;
using MvcBundleConfig.Models;

namespace System.Web.Optimization
{
    public static class BundleCollectionExtensions
    {
        public static void RegisterConfigurationBundles(this BundleCollection bundles, BundleConfigCollection bundleConfigCollection = null)
        {
            BundleConfigurationManager.Init(bundleConfigCollection);

            var config = BundleConfigurationManager.GetBundleConfigCollection();

            AddBundleConfiguration<CssMinify>(bundles, config.CssBundles);
            AddBundleConfiguration<JsMinify>(bundles, config.JsBundles);
        }

        private static void AddBundleConfiguration<T>(BundleCollection bundles, IEnumerable<BundleConfig> bundleConfigs)
            where T : IBundleTransform, new()
        {
            foreach (var bundleConfig in bundleConfigs)
            {
                var transform = bundleConfig.Minify
                    ? (IBundleTransform) new T()
                    : null;

                var bundle = String.IsNullOrWhiteSpace(bundleConfig.CdnPath)
                    ? new Bundle(bundleConfig.BundlePath, transform)
                    : new Bundle(bundleConfig.BundlePath, bundleConfig.CdnPath, transform);

                foreach (var file in bundleConfig.Files)
                    bundle.Include(file.FilePath);

                foreach (var directory in bundleConfig.Directories)
                    bundle.IncludeDirectory(directory.DirectoryPath, directory.SearchPattern, directory.SearchSubdirectories);

                bundles.Add(bundle);
            }
        }
    }
}
