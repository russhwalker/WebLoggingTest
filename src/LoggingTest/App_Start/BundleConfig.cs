﻿using System.Web;
using System.Web.Optimization;

namespace LoggingTest
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

        }
    }
}
