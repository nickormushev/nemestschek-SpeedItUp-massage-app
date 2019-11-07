using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MassageApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "Admin", action = "Index" }
            );
            routes.MapRoute(
                name: "Statistics",
                url: "admin/statistics/{action}",
                defaults: new {controller = "Statistics", action = "Index"}
            );

            routes.MapRoute(
                name: "EditSchedule",
                url: "admin/editSchedule/{action}",
                defaults: new { controller = "EditSchedule", action = "Index" }
            );


            routes.MapRoute(
                name: "CurrentSchedule",
                url: "admin/currentSchedule/{action}",
                defaults: new { controller = "CurrentSchedule", action = "Index" }
            );

            routes.MapRoute(
               name: "UserDailySchedule",
               url: "home/UserDailySchedule/{action}",
               defaults: new { controller = "UserDailySchedule", action = "Index" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
