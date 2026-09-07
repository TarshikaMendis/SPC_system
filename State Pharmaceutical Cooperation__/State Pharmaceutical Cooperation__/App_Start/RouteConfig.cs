using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace State_Pharmaceutical_Cooperation__
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ensure custom routes are added before the default route
            routes.MapRoute(
                name: "AdminManagement",
                url: "Admin/UserAdminMgmt/{action}/{id}",
                defaults: new { controller = "Admin", action = "UserAdminMgmt", id = UrlParameter.Optional }
            );

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

}
