namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Asos.MiniProject.ToDo.Backend.Api.Models;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;

    public class ToDoItemAdaptor : IToDoItemAdaptor
    {
        private readonly IDocumentClient documentClient;
        private readonly DocumentClientSettings settings;
        private readonly Uri collectionUri;

        public ToDoItemAdaptor(IDocumentClient documentClient, DocumentClientSettings settings)
        {
            this.documentClient = documentClient;
            this.settings = settings;
            this.collectionUri = UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, settings.CollectionId);
        }

        public async Task<IEnumerable<ToDoItem>> GetAllItemsAsync()
        {
            var query = this.documentClient.CreateDocumentQuery<ToDoItem>(this.collectionUri).AsDocumentQuery();
            var results = new List<ToDoItem>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<ToDoItem>());
            }

            return results;
        }

        public async Task CreateItemAsync(ToDoItem item)
        {
            item.Id = Guid.NewGuid().ToString();
            await this.documentClient.CreateDocumentAsync(this.collectionUri, item);
        }

        public async Task UpdateItemAsync(string id, ToDoItem item)
        {
            var docuemntUri = UriFactory.CreateDocumentUri(this.settings.DatabaseId, this.settings.CollectionId, id);
            await this.documentClient.ReplaceDocumentAsync(docuemntUri, item);
        }

    }
}