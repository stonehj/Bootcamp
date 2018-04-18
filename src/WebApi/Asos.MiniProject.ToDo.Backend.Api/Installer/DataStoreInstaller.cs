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

    public class DataStoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Uri databaseEndpointAddress;
            if (!Uri.TryCreate(ConfigurationManager.AppSettings["DocumentDatabase/EndpointAddress"], UriKind.Absolute, out databaseEndpointAddress))
            {
                throw new ConfigurationErrorsException("DocumentDatabase/EndpointAddress is an invalid Uri");
            }

            var databaseAuthKey = ConfigurationManager.AppSettings["DocumentDatabase/Key"];
            var databaseSettings = GetDatabaseSettings();
            var documentClient = new DocumentClient(databaseEndpointAddress, databaseAuthKey);

            DatabaseInitialiser.Initialise(documentClient, databaseSettings);

            container.Register(Component.For<DocumentClientSettings>().UsingFactoryMethod(() => databaseSettings).LifestyleSingleton());
            container.Register(Component.For<IDocumentClient>().UsingFactoryMethod(() => documentClient).LifestyleSingleton());
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