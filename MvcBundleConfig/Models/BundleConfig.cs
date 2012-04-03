using System.Collections.Generic;

namespace MvcBundleConfig.Models
{
    public class BundleConfig
    {
        public string BundlePath { get; set; }
        public bool Minify { get; set; }

        public IList<BundleDirectory> Directories { get; set; }
        public IList<BundleFile> Files { get; set; }
    }
}