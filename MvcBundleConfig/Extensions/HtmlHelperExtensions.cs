using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Optimization;
using MvcBundleConfig;
using MvcBundleConfig.Configuration;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CssBundle(this HtmlHelper helper, string bundlePath)
        {
            var jsTag = new TagBuilder("link");
            jsTag.MergeAttribute("rel", "stylesheet");
            jsTag.MergeAttribute("type", "text/css");

            return ReferenceBundle(helper, bundlePath, jsTag, "href");
        }

        public static MvcHtmlString JsBundle(this HtmlHelper helper, string bundlePath)
        {
            var jsTag = new TagBuilder("script");
            jsTag.MergeAttribute("type", "text/javascript");

            return ReferenceBundle(helper, bundlePath, jsTag, "src");
        }

        private static MvcHtmlString ReferenceBundle(HtmlHelper helper, string bundlePath, TagBuilder baseTag, string key)
        {
            var bundle = BundleTable.Bundles.GetBundleFor(bundlePath);
            if (bundle == null)
                throw new ArgumentException("Invalid Bundle Path", "bundlePath");

            var httpContext = helper.ViewContext.HttpContext;
            if (!BundleConfigurationManager.Ignore(httpContext))
            {
                baseTag.MergeAttribute(key, BundleTable.Bundles.ResolveBundleUrl(bundlePath));
                return new MvcHtmlString(baseTag.ToString());
            }

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var bundleContext = new BundleContext(helper.ViewContext.HttpContext, BundleTable.Bundles, urlHelper.Content(bundlePath));
            var htmlString = new StringBuilder();

            foreach (var file in bundle.EnumerateFiles(bundleContext))
            {
                var basePath = httpContext.Server.MapPath("~/");
                if (!file.FullName.StartsWith(basePath))
                    continue;

                var relPath = urlHelper.Content("~/" + file.FullName.Substring(basePath.Length));
                baseTag.MergeAttribute(key, relPath, true);
                htmlString.AppendLine(baseTag.ToString());
            }

            return new MvcHtmlString(htmlString.ToString());
        }
    }
}