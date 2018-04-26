using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Insurance
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254726
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/jquery-1.9.1.intellisense.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-ui-1.8.20.js",
                "~/Scripts/footable.js",
                "~/Scripts/jssor.js",
                "~/Scripts/jssor.slider.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ControlValidation").Include(
                "~/Scripts/Validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                  "~/Scripts/WebForms/WebForms.js",
                  "~/Scripts/WebForms/WebUIValidation.js",
                  "~/Scripts/WebForms/MenuStandards.js",
                  "~/Scripts/WebForms/Focus.js",
                  "~/Scripts/WebForms/GridView.js",
                  "~/Scripts/WebForms/DetailsView.js",
                  "~/Scripts/WebForms/TreeView.js",
                  "~/Scripts/WebForms/WebParts.js"));

            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));


            #region CSS / STYLE

            bundles.Add(new StyleBundle("~/bundles/BootstrapCss").Include(
                   "~/Content/bootstrap.css"
                   , "~/Content/bootstrap-theme.css"   
                   ,"~/Content/footable.core.css"
                   ));

            #endregion
            // Enable bundle optimization.
            BundleTable.EnableOptimizations = false;
        }
    }
}