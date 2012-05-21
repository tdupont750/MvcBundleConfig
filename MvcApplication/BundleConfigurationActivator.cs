using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(/*$rootnamespace$*/MvcApplication.BundleConfigurationActivator), "Activate")]
namespace MvcApplication /* $rootnamespace$ */
{
    public static class BundleConfigurationActivator
    {
        public static void Activate()
        {
            BundleTable.Bundles.RegisterConfigurationBundles();
        }
    }
}