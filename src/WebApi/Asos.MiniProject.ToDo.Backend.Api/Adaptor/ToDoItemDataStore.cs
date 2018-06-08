namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Models;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;

    public class ToDoItemDataStore : IToDoItemDataStore
    {
        private readonly IDocumentClient documentClient;
        private readonly DocumentClientSettings documentClientSettings;

        public ToDoItemDataStore(IDocumentClient documentClient, DocumentClientSettings documentClientSettings)
        {
            this.documentClient = documentClient;
            this.documentClientSettings = documentClientSettings;
        }

        public Task<IEnumerable<ToDoItem>> GetAllItemsAsync()
        {
            IEnumerable<ToDoItem> toDoItems = this.documentClient.CreateDocumentQuery<ToDoItem>(this.CreateDocumentCollectionUri()).AsEnumerable<ToDoItem>();

            return Task.FromResult(toDoItems);
        }

        public async Task<ToDoItem> GetOneItem(string id)
        {
            Document document = await (dynamic)this.documentClient.ReadDocumentAsync(this.CreateDocumentUri(id));

            // ReSharper disable once SuspiciousTypeConversion.Global
            return (ToDoItem)(dynamic)document;
        }

        public async Task AmendExistingItem(ToDoItem item)
        {
            await this.documentClient.UpsertDocumentAsync(this.CreateDocumentCollectionUri(), item);
        }

        public async Task DeleteExistingItem(ToDoItem item)
        {
            await this.documentClient.DeleteDocumentAsync(this.CreateDocumentUri(item.Id));
        }

        public async Task AddOneItem(ToDoItem item)
        {
            await this.documentClient.CreateDocumentAsync(this.CreateDocumentCollectionUri(), item);
        }

        private Uri CreateDocumentCollectionUri()
        {
            return UriFactory.CreateDocumentCollectionUri(this.documentClientSettings.DatabaseId, this.documentClientSettings.CollectionId);
        }

        private Uri CreateDocumentUri(string id)
        {
            return UriFactory.CreateDocumentUri(this.documentClientSettings.DatabaseId, this.documentClientSettings.CollectionId, id);
        }
    }
}