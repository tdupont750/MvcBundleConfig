using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using MvcBundleConfig.Configuration;

namespace System.Web.Optimization
{
    public static class BundleCollectionExtensions
    {
        public static void RegisterConfigurationBundles(this BundleCollection bundles)
        {
            var config = BundleConfigurationManager.GetBundleConfiguration();

            AddBuldeConfiguration<CssMinify>(bundles, config.CssBundles);
            AddBuldeConfiguration<JsMinify>(bundles, config.JsBundles);
        }

        private static void AddBuldeConfiguration<T>(BundleCollection bundles, BundleConfigurationElementCollection configCollection)
            where T : IBundleTransform, new()
        {
            foreach (BundleConfigurationElement bundleConfig in configCollection)
            {
                var transform = bundleConfig.Minify
                    ? (IBundleTransform)new T()
                    : new NoTransform();

                var bundle = new Bundle(bundleConfig.BundlePath, transform);

                foreach (BundleFileConfigurationElement file in bundleConfig.Files)
                    bundle.AddFile(file.FilePath, file.ThrowIfNotExist);

                foreach (BundleDirectoryConfigurationElement directory in bundleConfig.Directories)
                    bundle.AddDirectory(directory.DirectoryPath, directory.SearchPattern, directory.SearchSubdirectories, directory.ThrowIfNotExist);

                bundles.Add(bundle);
            }
        }
    }
}
