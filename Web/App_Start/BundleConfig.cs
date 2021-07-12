﻿using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //Jqueryui
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // SweetAlert
            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include("~/Scripts/sweetalert.min.js"));

            //jQuery.Unobtrusive
            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                       "~/Scripts/jquery.unobtrusive*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       //"~/Content/bootstrap.css"));
                       "~/Content/font-awesome.css",
                         "~/Content/font-awesome.min.css",
                          "~/Content/Logout.css",
                           "~/Content/Details.css",
                             "~/Content/jquery-ui.css", "~/Content/sweetalert.css",
             "~/Content/bootstrap-flatly.min.css"));
            // "~/Content/site.css"
        }
    }
}
