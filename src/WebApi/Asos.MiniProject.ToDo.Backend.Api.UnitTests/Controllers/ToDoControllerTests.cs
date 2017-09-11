namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http.Results;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Controllers;
    using Asos.MiniProject.ToDo.Backend.Api.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ToDoControllerTests
    {
        private Mock<IToDoItemAdaptor> todoAdapter;
        private ToDoController toDoController;

        [SetUp]
        public void Setup()
        {
            this.todoAdapter = new Mock<IToDoItemAdaptor>();
            this.toDoController = new ToDoController(this.todoAdapter.Object);
        }

        [Test]
        public void Getting_All_Items_Should_Return_All_Items()
        {
            var items = new List<ToDoItem> { new ToDoItem(), new ToDoItem() };
            this.todoAdapter.Setup(x => x.GetAllItemsAsync()).ReturnsAsync(items);

            var result = this.toDoController.GetItems().GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<OkNegotiatedContentResult<IEnumerable<ToDoItem>>>());

            var resultItems = ((OkNegotiatedContentResult<IEnumerable<ToDoItem>>)result).Content;
            Assert.NotNull(result);
            Assert.That(resultItems, Is.EqualTo(items));
        }

        [Test]
        public void Creating_An_Item_Should_Persist_A_New_Item()
        {
            var item = new ToDoItem();
            item.Id = "123";

            var result = this.toDoController.CreateItem(item).GetAwaiter().GetResult();

            Assert.That(result, Is.InstanceOf<CreatedAtRouteNegotiatedContentResult<ToDoItem>>());
            var resultMessage = (CreatedAtRouteNegotiatedContentResult<ToDoItem>)result;
            Assert.That(resultMessage.RouteName, Is.EqualTo("CreateItem"));
            Assert.That(resultMessage.RouteValues["id"], Is.EqualTo(item.Id));
            this.todoAdapter.Verify(x => x.CreateItemAsync(item), Times.Once);
        }

        [Test]
        public void Updating_An_Item_Should_Persist_The_Update()
        {
            var item = new ToDoItem();
            var id = "123";

            this.toDoController.UpdateItem(item, id).GetAwaiter().GetResult();
            this.todoAdapter.Verify(x => x.UpdateItemAsync(id, item), Times.Once);
        }
    }
}
