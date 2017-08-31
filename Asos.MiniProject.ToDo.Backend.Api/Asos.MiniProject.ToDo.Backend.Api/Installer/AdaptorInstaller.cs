namespace Asos.MiniProject.ToDo.Backend.Api.Installer
{
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class AdaptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<IToDoItemAdaptor>().WithServiceDefaultInterfaces());
        }
    }
}