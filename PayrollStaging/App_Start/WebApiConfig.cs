using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace PayrollStaging
{
    public static class WebApiConfig
    {
		public static string UrlPrefix { get { return "api"; } }
		public static string UrlPrefixRelative { get { return "~/api"; } }
		public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services

			// Web API routes
			config.EnableCors();
			config.MapHttpAttributeRoutes();

			config.Formatters.JsonFormatter.SupportedMediaTypes
			.Add(new MediaTypeHeaderValue("text/html"));
			//config.Routes.MapHttpRoute(
			//    name: "DefaultApi",
			//    routeTemplate: "api/{controller}/{id}",
			//    defaults: new { id = RouteParameter.Optional }
			//);
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "ApiUserModel",
				routeTemplate: "api/UserModels/{controller}/{source}",
				defaults: new { source = RouteParameter.Optional }
			);
		}
    }
}
