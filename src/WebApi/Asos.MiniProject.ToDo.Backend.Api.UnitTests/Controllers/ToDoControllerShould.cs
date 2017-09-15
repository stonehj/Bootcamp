namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using Moq;
    using NUnit.Framework;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Controllers;

    [TestFixture]
    public class ToDoControllerShould
    {
        private Mock<IToDoItemDataStore> _todoAdapter;
        private ToDoController _toDoController;

        [SetUp]
        public void Setup()
        {
            _todoAdapter = new Mock<IToDoItemDataStore>();
            _toDoController = new ToDoController(this._todoAdapter.Object);
        }

        [Test]
        public void Be_able_to_return_all_items()
        {
            // Write a test
        }
    }
}
