using System.Web;
using System.Web.Optimization;

namespace EnozomFoodcourtTask
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Style css bundle
            bundles.Add(new StyleBundle("~/Content/Style").Include(
                "~/Content/bootstrap.css",
                "~/Content/animate.css",
                 "~/Content/ng-table.css"
                ));

            ///mvc jquery bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery.js",
                "~/Scripts/bootstrap.js"
                
                ));

            //angular bundle

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
              "~/Scripts/angular/angular.js",
              "~/Scripts/angular-animate/angular-animate.js",
              "~/Scripts/angular-cookies/angular-cookies.js",
              "~/Scripts/angular-resource/angular-resource.js",
              "~/Scripts/angular-sanitize/angular-sanitize.js",
              "~/Scripts/angular-touch/angular-touch.js",
              "~/Scripts/angular-ui-router/release/angular-ui-router.js",
              "~/Scripts/ngstorage/ngStorage.js",
              "~/Scripts/angular-ui-utils/ui-utils.js",
              "~/Scripts/angular-bootstrap/ui-bootstrap-tpls.js",
              "~/Scripts/angular-ui-bootstrap-modal/angular-ui-bootstrap-modal.js",
             
              "~/Scripts/FileSaver.js",

              "~/Scripts/ng-Table/ng-table.js"


              ));

            //App bundle for all my js modules,controllers,services,factories,route configs

            bundles.Add(new ScriptBundle("~/bundles/app").Include(

            "~/App/Services/extensions.js",
            "~/App/Services/webApi.links.js",
            "~/App/ControlPanel/admin.module.js",
            "~/App/Site/site.module.js",
            "~/App/app.module.js",
            "~/App/app.controller.js",
            "~/App/ControlPanel/admin.route.js",
            "~/App/ControlPanel/Store/store.controller.js",
            "~/App/Factories/store.factory.js",
             "~/App/ControlPanel/Store/store-route.js",
            "~/App/Site/site.route.js",
             "~/App/Site/Store/store-route.js",
            "~/App/Site/Store/storeNavigation.controller.js",

            
            "~/Scripts/ui-load.js"
            ));

            ///directives
            bundles.Add(new ScriptBundle("~/bundles/directives").Include(
            "~/App/Directives/modal.js",
            "~/App/Directives/confirmClick.js",
            "~/App/Directives/file-uloader.js"
            ));
        }

    }
}
