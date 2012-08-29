namespace MvcBundleConfig.Models
{
    public class BundleDirectory
    {
        public string DirectoryPath { get; set; }
        public string SearchPattern { get; set; }
        public bool SearchSubdirectories { get; set; }
    }
}