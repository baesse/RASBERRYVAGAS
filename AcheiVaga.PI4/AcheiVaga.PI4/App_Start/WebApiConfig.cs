using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AcheiVaga.PI4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "AcheiVaga/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
