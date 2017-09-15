namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Controllers;
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
            Assert.Fail("Need to write a test!");
        }
    }
}
