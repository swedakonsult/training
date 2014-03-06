using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestWebFunctionality
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Damaged",
                url: "https/{on}/{iterations}",
                defaults: new { controller = "Application", action = "RunHttps", iterations = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "RunHttps",
                url: "{controller}/{action}/{on}/{domain}/{iterations}",
                defaults: new { controller = "Application", action = "RunHttps", on = "www%2Egoogle%2Ecom", domain = UrlParameter.Optional, iterations = UrlParameter.Optional },
                constraints: new { domain = @"[a-zA-Z]{1,10}\.[a-zA-Z]{1,30}\.[a-zA-Z]{2,5}", iterations = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{on}",
                defaults: new { controller = "Home", action = "Index", on = UrlParameter.Optional }
            );
        }
    }
}
