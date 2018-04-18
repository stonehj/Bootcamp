using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Asos.MiniProject.ToDo.Backend.Api.Models;
    using System.Net;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Newtonsoft.Json;


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
                UriFactory.CreateDocumentCollectionUri(_documentClientSettings.DatabaseId,
                    _documentClientSettings.CollectionId)).AsEnumerable<ToDoItem>();

            return Task.FromResult(toDoItems);
        }

        public async Task<ToDoItem> GetOneItem(string id)
        {
            Document document = await (dynamic)this._documentClient.ReadDocumentAsync(
                UriFactory.CreateDocumentUri(_documentClientSettings.DatabaseId, _documentClientSettings.CollectionId,
                    id));

            //var todoDocument = (dynamic) document;

            //return new ToDoItem()
            //{
            //    Completed = todoDocument.Completed,
            //    Description = todoDocument.Description,
            //    DateAdded = todoDocument.DateAdded,
            //    DueBy = todoDocument.DueBy,
            //    Id = todoDocument.Id
            //};

            return (ToDoItem) (dynamic) document;
        }

        public async Task AmendExistingItem(ToDoItem item)
        {
            await this._documentClient.UpsertDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_documentClientSettings.DatabaseId,
                    _documentClientSettings.CollectionId), item);
        }

        public Task<ToDoItem> DeleteExistingItem(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public async Task AddOneItem(ToDoItem item)
        {
            await this._documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_documentClientSettings.DatabaseId,
                    _documentClientSettings.CollectionId), item);
        }
    }
}