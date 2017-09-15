namespace Asos.MiniProject.ToDo.Backend.Api
{
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Backend.Api.Installer;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureContainer(GlobalConfiguration.Configuration);
        }

        private static void ConfigureContainer(HttpConfiguration configuration)
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.Containing<ControllerInstaller>());

            configuration.DependencyResolver = new WindsorHttpDependencyResolver(container);
        }
    }
}
