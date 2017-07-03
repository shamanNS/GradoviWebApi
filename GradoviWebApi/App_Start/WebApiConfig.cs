using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using GradoviWebApi.Resolver;
using GradoviWebApi.Repository.Interfaces;
using GradoviWebApi.Repository;

namespace GradoviWebApi
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            // CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Unity
            var container = new UnityContainer();
            container.RegisterType<IGradRepository, GradRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDrzavaRepository, DrzavaRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
