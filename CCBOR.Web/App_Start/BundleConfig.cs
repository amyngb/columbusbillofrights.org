using System.Web;
using System.Web.Optimization;

namespace CCBOR.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jQueryCore").Include(
                        "~/Content/assets/plugins/jquery/jquery-3.3.1.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jQueryFeatures").Include(
                     "~/Content/assets/plugins/form.validate/jquery.form.min.js",
                     "~/Content/assets/plugins/form.validate/jquery.validation.min.js",
                     "~/Content/assets/plugins/toastr/toastr.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/siteScripts").Include(
                     "~/Content/assets/js/scripts.js",
                     "~/Scripts/Custom/Common.js"
                     ));

            #endregion

            #region Styles

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                        .Include("~/Content/assets/plugins/bootstrap/css/bootstrap.min.css")
                        );

            bundles.Add(new StyleBundle("~/Content/core")
               .Include("~/Content/assets/css/essentials.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/css/layout.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/css/ccbor.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/css/header-1.css", new CssRewriteUrlTransform())
               .Include("~/Content/assets/css/color_scheme/blue.css", new CssRewriteUrlTransform())
               );

            #endregion

        }
    }
}
