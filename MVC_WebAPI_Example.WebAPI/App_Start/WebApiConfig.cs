using System.Net.Http.Formatting;
using System.Web.Http;

namespace MVC_WebAPI_Example.WebAPI
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
                routeTemplate: "api/{folder}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // returrn Json instead XML;
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
