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
                    ? (IBundleTransform)new T()
                    : new NoTransform();

                var bundle = new Bundle(bundleConfig.BundlePath, transform);

                foreach (var file in bundleConfig.Files)
                    bundle.AddFile(file.FilePath, file.ThrowIfNotExist);

                foreach (var directory in bundleConfig.Directories)
                    bundle.AddDirectory(directory.DirectoryPath, directory.SearchPattern, directory.SearchSubdirectories, directory.ThrowIfNotExist);

                bundles.Add(bundle);
            }
        }
    }
}
