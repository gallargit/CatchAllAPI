using System.Web.Mvc;
using System.Web.Routing;

namespace CatchAll
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CatchAll", action = "Get", id = UrlParameter.Optional }
            );
        }
    }
}
