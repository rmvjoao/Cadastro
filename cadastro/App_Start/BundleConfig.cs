using System.Web;
using System.Web.Optimization;

namespace cadastro
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css/icons/icomoon/styles.css",
                      "~/assets/css/bootstrap.css",
                      "~/assets/css/core.css",
                      "~/assets/css/components.css",
                      "~/assets/css/colors.css"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/assets").Include(
                    "~/assets/js/plugins/loaders/pace.min.js",
                    "~/assets/js/core/libraries/jquery.min.js",
                    "~/assets/js/core/libraries/bootstrap.min.js",
                    "~/assets/js/plugins/loaders/blockui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                    "~/assets/js/plugins/forms/styling/uniform.min.js",
                    "~/assets/js/core/app.js",
                    "~/assets/js/pages/login.js"));

            bundles.Add(new ScriptBundle("~/Script/MeusScripts").Include(
                    "~/Scripts/MeusScripts/Global.js", 
                    "~/Scripts/MeusScripts/admCadastro.js",
                    "~/Scripts/MeusScripts/admLogin.js" ));



        }
    }
}
