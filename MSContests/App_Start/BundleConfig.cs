using System.Web;
using System.Web.Optimization;

namespace MSContests
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/mobile").Include(
               "~/Scripts/jquery-mobile/jquery.min.js",
                "~/Scripts/jquery-mobile/jquery.mobile-1.4.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/metro").Include(
                       "~/Scripts/jquery.countdown.js",
                       "~/Scripts/jquery.countdown.min.js",
                       "~/Scripts/BackToTop.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css", 
                      "~/Content/stylish-portfolio.css", 
                      "~/Content/Site.css"));//,"~/Content/pure.min.css","~/Content/main.css"

            bundles.Add(new StyleBundle("~/Content/mobile").Include(
                      "~/Content/jquery.mobile-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile.external-png-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile.icons-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile.inline-png-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile.inline-svg-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile.structure-1.4.3.min.css",
                      "~/Content/jquery-mobile/jquery.mobile.theme-1.4.3.min.css"
                      ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
