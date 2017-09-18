namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using Moq;
    using NUnit.Framework;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Controllers;
    using System.Threading.Tasks;

    [TestFixture]
    public class ToDoControllerShould
    {
        private Mock<IToDoItemDataStore> _todoDataStore;

        [SetUp]
        public void Setup()
        {
            _todoDataStore = new Mock<IToDoItemDataStore>();
        }

        [Test]
        public async Task Be_able_to_return_all_items()
        {
            // Write a test
        }
    }
}
