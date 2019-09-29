using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaiustHostel
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			//enable cross origin
			EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:3000", "*", "*");
			config.EnableCors(cors);

			//json formatting
			var settings = config.Formatters.JsonFormatter.SerializerSettings;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Formatting = Formatting.Indented;
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
	            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
