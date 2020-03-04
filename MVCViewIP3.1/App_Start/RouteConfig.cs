using System.Web.Mvc;
using System.Web.Routing;

namespace MVCViewIP3._1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Root",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
           name: "Create",
           url: "{controller}/{action}",
           defaults: new { controller = "Home", action = "Create" }
       );
            routes.MapRoute(
    name: "Default",
     url: "{controller}/{action}/{id}",
   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    new[] { "MVCViewIP3.1.Controllers" }
);
        }

    }
}
