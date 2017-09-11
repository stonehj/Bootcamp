namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    public class DocumentClientSettings
    {
        public DocumentClientSettings(string collectionId, string databaseId)
        {
            this.CollectionId = collectionId;
            this.DatabaseId = databaseId;
        }

        public string DatabaseId { get; private set; }

        public string CollectionId { get; private set; }
    }
}