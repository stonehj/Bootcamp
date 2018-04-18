namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Models;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;


    public class ToDoItemDataStore : IToDoItemDataStore
    {
        private readonly IDocumentClient _documentClient;
        private readonly DocumentClientSettings _documentClientSettings;

        public ToDoItemDataStore(IDocumentClient documentClient, DocumentClientSettings documentClientSettings)
        {
            _documentClient = documentClient;
            _documentClientSettings = documentClientSettings;
        }

        public Task<IEnumerable<ToDoItem>> GetAllItemsAsync()
        {
            IEnumerable<ToDoItem> toDoItems = this._documentClient.CreateDocumentQuery<ToDoItem>(
                CreateDocumentCollectionUri()).AsEnumerable<ToDoItem>();

            return Task.FromResult(toDoItems);
        }

        public async Task<ToDoItem> GetOneItem(string id)
        {
            Document document = await (dynamic)this._documentClient.ReadDocumentAsync(CreateDocumentUri(id));

            return (ToDoItem) (dynamic) document;
        }

        public async Task AmendExistingItem(ToDoItem item)
        {
            await this._documentClient.UpsertDocumentAsync(CreateDocumentCollectionUri(), item);
        }

        public async Task DeleteExistingItem(ToDoItem item)
        {
            await this._documentClient.DeleteDocumentAsync(CreateDocumentUri(item.Id));
        }

        public async Task AddOneItem(ToDoItem item)
        {
            await this._documentClient.CreateDocumentAsync(CreateDocumentCollectionUri(), item);
        }

        private Uri CreateDocumentCollectionUri()
        {
            return UriFactory.CreateDocumentCollectionUri(_documentClientSettings.DatabaseId, _documentClientSettings.CollectionId);
        }

        private Uri CreateDocumentUri(string id)
        {
            return UriFactory.CreateDocumentUri(_documentClientSettings.DatabaseId, _documentClientSettings.CollectionId, id);
        }
    }
}