namespace Asos.MiniProject.ToDo.Backend.Api.Installer
{
    using Asos.MiniProject.ToDo.Backend.Api.Controllers;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .InSameNamespaceAs<ToDoController>()
                    .Configure(c => c.LifestyleScoped()));
        }
    }
}