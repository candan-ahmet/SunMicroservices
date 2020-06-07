using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SunFramework.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "RouteApi",
                routeTemplate: "route/{servicename}/{controllername}/{param}",
                defaults: new { controller = "Route" }
            );
            config.Routes.MapHttpRoute(
                name: "RouteApi2",
                routeTemplate: "route/{servicename}/{controllername}/",
                defaults: new { controller = "Route" }
            );
        }
    }
}
