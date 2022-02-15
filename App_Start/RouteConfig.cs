using System.Web.Mvc;
using System.Web.Routing;

namespace POS_OJT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Dashboard",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Dashboard", action = "Dashboard", id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Category",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Warehouse",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Warehouse", action = "Index", id = UrlParameter.Optional, name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional, name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sale",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Sale", action = "Index", id = UrlParameter.Optional }
            );
          
            routes.MapRoute(
             name: "Stocks",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Stocks", action = "Index", id = UrlParameter.Optional }
         );
        }
    }
}