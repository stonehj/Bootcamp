namespace Asos.MiniProject.ToDo.Backend.Api.Installer
{
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;

    public static class DatabaseInitialiser
    {
        public static void Initialise(IDocumentClient client, DocumentClientSettings settings)
        {
            CreateCollectionIfNotExists(client, settings);
        }

        private static void CreateCollectionIfNotExists(IDocumentClient client, DocumentClientSettings settings)
        {
            try
            {
                client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, settings.CollectionId)).GetAwaiter().GetResult();
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(settings.DatabaseId),
                        new DocumentCollection { Id = settings.CollectionId });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}