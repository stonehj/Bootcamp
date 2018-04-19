namespace Asos.MiniProject.ToDo.Backend.Api
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableSystemDiagnosticsTracing();

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
