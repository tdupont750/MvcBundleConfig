using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof($rootnamespace$.BundleConfigurationActivator), "Activate")]
namespace $rootnamespace$
{
    public static class BundleConfigurationActivator
    {
        public static void Activate()
        {
            BundleTable.Bundles.RegisterConfigurationBundles();
        }
    }
}