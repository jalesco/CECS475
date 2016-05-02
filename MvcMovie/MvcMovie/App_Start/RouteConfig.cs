using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMovie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //This is the default url that is run when we launch the app
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //If we want to change the route data url, we need to make another instance of routes.MapRoute, without the "defaults" parameter
            routes.MapRoute(
                name: "Hello",
                url: "{controller}/{action}/{name}/{id}"              
            );

            routes.MapRoute(
                name: "Titles",
                url: "{controller}/{action}"
            );

        }//end main
    }//end class
}//end namespace
