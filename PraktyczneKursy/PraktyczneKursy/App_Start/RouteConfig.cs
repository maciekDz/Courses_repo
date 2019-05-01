using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PraktyczneKursy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("Glimpse.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CoursesList",
                url: "Category/{categoryName}",
                defaults: new { controller = "Courses", action = "List" });

            routes.MapRoute(
                name: "StaticPages",
                url: "page/{name}.cshtml",
                defaults: new { controller = "Home", action = "StaticPages" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
