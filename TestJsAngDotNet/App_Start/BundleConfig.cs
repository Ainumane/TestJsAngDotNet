﻿namespace TestJsAngDotNet
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js"));


            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Styles/angular-selector.css"));

            bundles.Add(new StyleBundle("~/bundles/modules").Include(
                      "~/Scripts/angular-selector.js"));

            bundles.Add(new ScriptBundle("~/bundles/application").IncludeDirectory("~/Scripts/app", "*.js"));
        }
    }
}
