using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
using Asos.MiniProject.ToDo.Backend.Api.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Adaptor
{
    public class ToDoItemDataStoreShould
    {
        private Mock<IDocumentClient> toDoDocumentClient;
        private ToDoItemDataStore toDoItemDataStore;

        [SetUp]
        public void Setup()
        {
            this.toDoDocumentClient = new Mock<IDocumentClient>();
            this.toDoItemDataStore = new ToDoItemDataStore(this.toDoDocumentClient.Object, new DocumentClientSettings(string.Empty, string.Empty));
        }

        [Test]
        public async Task Should_add_one_item()
        {
            // arrange
            var item = new ToDoItem();
            item.Description = "description";
            item.Completed = true;
            item.DateAdded = DateTime.Now.AddDays(-1);
            item.DueBy = DateTime.Now.AddDays(1);

            //act
            await this.toDoItemDataStore.AddOneItem(item);

            //assert
            this.toDoDocumentClient.Verify(x => x.CreateDocumentAsync(It.IsAny<Uri>(), It.IsAny<object>(), It.IsAny<RequestOptions>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public async Task Should_get_one_item_by_id()
        {
            var expectedId = "1";
            var todoitem = new ToDoItem() { Id = expectedId };
         
            var document = new Document();
            document.LoadFrom(new JsonTextReader(new StringReader(todoitem.ToString())));
            var mockResponse = new ResourceResponse<Document>(document);

            this.toDoDocumentClient.Setup(x => x.ReadDocumentAsync(It.IsAny<Uri>(), It.IsAny<RequestOptions>()))
                .ReturnsAsync(new ResourceResponse<Document>(mockResponse));

            var toDoItem = await this.toDoItemDataStore.GetOneItem(expectedId);

            Assert.That(toDoItem.Id, Is.EqualTo(expectedId.ToString()));
        }
        [Test]
        public async Task Should_get_all_items()
        {
            var expectedId = 1;
            var todoitem = new ToDoItem() { Id = expectedId.ToString() };

            var mockResponsesList = new List<ToDoItem>()
            {
                todoitem,
                todoitem
            };

            var lst = (from d in mockResponsesList select d).AsQueryable().OrderBy(x => x.Id);

            this.toDoDocumentClient.Setup(x => x.CreateDocumentQuery<ToDoItem>(It.IsAny<Uri>(), It.IsAny<FeedOptions>()))
                .Returns(lst);

            var toDoItems = await this.toDoItemDataStore.GetAllItemsAsync();

            Assert.That(toDoItems.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task Should_amend_existing_item_by_item_id()
        {
            await this.toDoItemDataStore.AmendExistingItem(new ToDoItem());

            this.toDoDocumentClient.Verify(x => x.UpsertDocumentAsync(It.IsAny<Uri>(), It.IsAny<object>(),It.IsAny<RequestOptions>(),It.IsAny<bool>()));
        }
    }
}
