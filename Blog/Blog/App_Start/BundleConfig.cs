using System.Web;
using System.Web.Optimization;

namespace BlogSite
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js",
                //  "~/Scripts/knockout-3.0.0.js",
                  "~/Scripts/knockout-3.0.0.debug.js"
            ));
            //bundles.Add(new ScriptBundle("~/bundles/article").Include(
            //           "~/Scripts/jquery-1.10.2.js",
            //           "~/Scripts/jquery-1.9.1.js",
            //           "~/Scripts/jquery-ui-1.10.4.js",
            //           "~/Scripts/jquery.unobtrusive-ajax.js",
            //           "~/Scripts/jquery.validate.js",
            //           "~/Scripts/jquery.validate.unobtrusive.js",
            //           "~/Scripts/toggle.js"
                        
            //        ));

            bundles.Add(new ScriptBundle("~/bundles/dialog").Include(
             "~/Scripts/jquery-ui.js",
             "~/Scripts/jquery-1.9.1.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css", "~/Content/bootstrap.css", "~/Content/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                     "~/Content/themes/base/jquery.ui.css",
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                       "~/Content/themes/base/jquery.ui.slider.css",
                       "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                    //    "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            //jQuery 1.10
            bundles.Add(new ScriptBundle("~/bundles/jqueryuioneten").Include(
               "~/Scripts/jquery-1.10.2.js",
               "~/Content/themes/ui/jquery.ui.core.js",
               "~/Content/themes/ui/jquery.ui.widget.js",
               "~/Content/themes/ui/jquery.ui.button.js"));
         
        }
    }
}