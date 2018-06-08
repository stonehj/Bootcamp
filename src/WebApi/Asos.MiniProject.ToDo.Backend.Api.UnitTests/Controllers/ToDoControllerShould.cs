namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using Api.Adaptor;
    using Api.Controllers;

    using Models;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ToDoControllerShould
    {
        private Mock<IToDoItemDataStore> _todoDataStore;
        private ToDoController _toDoController;
        

        [SetUp]
        public void Setup()
        {
            this._todoDataStore = new Mock<IToDoItemDataStore>();
            this._toDoController = new ToDoController(this._todoDataStore.Object);
            
        }

        [Test]
        public void Be_able_to_return_all_items()
        {
            // set up mock data source
            var items = new List<ToDoItem>{ new ToDoItem(), new ToDoItem() };
            this._todoDataStore.Setup(x => x.GetAllItemsAsync()).ReturnsAsync(items);

            // call method on controller that executes GetItems
            var result = _toDoController.GetItems().GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkNegotiatedContentResult<IEnumerable<ToDoItem>>>());

            var resultItems = ((OkNegotiatedContentResult<IEnumerable<ToDoItem>>)result).Content;
            Assert.NotNull(result);
            Assert.That(resultItems, Is.EqualTo(items));
        }

        [Test]
        public async  Task Be_able_to_return_one_item_by_item_id()
        {
            // set up mock data source
            var item = new ToDoItem();
            this._todoDataStore.Setup(x => x.GetOneItem("1")).ReturnsAsync(item);

            var result = this._toDoController.GetItem("1").GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkNegotiatedContentResult<ToDoItem>>());

            var resultItems = ((OkNegotiatedContentResult<ToDoItem>)result).Content;
            Assert.NotNull(result);
            Assert.That(resultItems, Is.EqualTo(item));

        }

        [Test]
        public async Task Be_able_to_add_one_item()
        {
            var item = new ToDoItem();

            var result = this._toDoController.AddOneItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkResult>());
            this._todoDataStore.Verify(x => x.AddOneItem(item));
            
        }

        [Test]
        public async Task Be_able_to_amend_existing_item_by_item_id()
        {
            var item = new ToDoItem();

            var result = this._toDoController.AmendExistingItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkResult>());
            this._todoDataStore.Verify(x => x.AmendExistingItem(item));

        }

        [Test]
        public async Task Be_able_to_delete_one_item()
        {
            var item = new ToDoItem();

            var result = this._toDoController.DeleteOneItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkResult>());
            this._todoDataStore.Verify(x => x.DeleteExistingItem(item));
        }
    }
}

