using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MvcApplication.BundleConfigurationActivator), "Activate")]
namespace MvcApplication
{
    public static class BundleConfigurationActivator
    {
        public static void Activate()
        {
            BundleTable.Bundles.RegisterConfigurationBundles();
        }
    }
}