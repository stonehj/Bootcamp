namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using Moq;
    using NUnit.Framework;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Controllers;
    using Asos.MiniProject.ToDo.Backend.Api.Models;
    using System.Threading.Tasks;

    [TestFixture]
    public class ToDoControllerShould
    {
        private Mock<IToDoItemDataStore> todoDataStore;
        private ToDoController toDoController;
        

        [SetUp]
        public void Setup()
        {
            this.todoDataStore = new Mock<IToDoItemDataStore>();
            this.toDoController = new ToDoController(this.todoDataStore.Object);
            
        }

        [Test]
        public void Be_able_to_return_all_items()
        {
            // set up mock data source
            var items = new List<ToDoItem>{ new ToDoItem(), new ToDoItem() };
            this.todoDataStore.Setup(x => x.GetAllItemsAsync()).ReturnsAsync(items);

            //call method on controller that executes GetItems
            var result = this.toDoController.GetItems().GetAwaiter().GetResult();

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
            this.todoDataStore.Setup(x => x.GetOneItem("1")).ReturnsAsync(item);

            var result = this.toDoController.GetItem("1").GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkNegotiatedContentResult<ToDoItem>>());

            var resultItems = ((OkNegotiatedContentResult<ToDoItem>)result).Content;
            Assert.NotNull(result);
            Assert.That(resultItems, Is.EqualTo(item));

        }

        [Test]
        public async Task Be_able_to_add_one_item()
        {
            var item = new ToDoItem();

            var result = this.toDoController.AddOneItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkResult>());
            this.todoDataStore.Verify(x => x.AddOneItem(item));
            
        }

        [Test]
        public async Task Be_able_to_amend_existing_item_by_item_id()
        {
            var item = new ToDoItem();

            var result = this.toDoController.AmendExistingItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkResult>());
            this.todoDataStore.Verify(x => x.AmendExistingItem(item));

        }

        [Test]
        public async Task Be_able_to_delete_one_item()
        {
            var item = new ToDoItem();

            var result = this.toDoController.DeleteOneItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkResult>());
            this.todoDataStore.Verify(x => x.DeleteExistingItem(item));
        }
    }
}

