using System.Web.Http;
using Asos.MiniProject.ToDo.Backend.Api;
using Swashbuckle.Application;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Asos.MiniProject.ToDo.Backend.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Asos.MiniProject.ToDo.Backend.Api"); 
                    })
                .EnableSwaggerUi(c => { });
        }
    }
}
