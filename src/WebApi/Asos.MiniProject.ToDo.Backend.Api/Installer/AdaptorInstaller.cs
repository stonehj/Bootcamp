namespace Asos.MiniProject.ToDo.Backend.Api.Installer
{
    using System;
    using System.Configuration;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;

    public class AdaptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Uri databaseEndpointAddress;
            if (!Uri.TryCreate(ConfigurationManager.AppSettings["DocumentDatabase/EndpointAddress"], UriKind.Absolute, out databaseEndpointAddress))
            {
                throw new ConfigurationErrorsException("DocumentDatabase/EndpointAddress is an invalid Uri");
            }

            var databaseAuthKey = ConfigurationManager.AppSettings["DocumentDatabase/Key"];

            container.Register(Component.For<DocumentClientSettings>().UsingFactoryMethod(GetDatabaseSettings).LifestyleSingleton());
            container.Register(Component.For<IDocumentClient>().UsingFactoryMethod(() => new DocumentClient(databaseEndpointAddress, databaseAuthKey)).LifestyleSingleton());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<IToDoItemDataStore>().WithServiceDefaultInterfaces());
        }

        private static DocumentClientSettings GetDatabaseSettings()
        {
            var database = ConfigurationManager.AppSettings["DocumentDatabase/Name"];
            var todoItemCollectionId = ConfigurationManager.AppSettings["DocumentDatabase/ToDoItemCollectionId"];

            return new DocumentClientSettings(todoItemCollectionId, database);
        }
    }
}