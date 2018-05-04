using Asos.MiniProject.ToDo.Backend.Api.Models;
using Asos.MiniProject.ToDo.Backend.Api.Validators;
using FluentAssert;
using NUnit.Framework;
using TestStack.BDDfy;

namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    public class ToDoItemValidatorShould
    {
        private ToDoItem _toDoItem;
        private bool result;

        [Test]
        public void ValidateToDoItemDescription()
        {
            this.Given(_ => this.GivenAToDoItemWithNoDescription())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnFalse())
                .BDDfy();
        }

        private void ThenReturnFalse()
        {
            result.ShouldBeEqualTo(false);
        }

        private void WhenValidatingAToDoItem()
        {
            var toDoItemValidator = new ToDoItemValidator();
            result = toDoItemValidator.Validate(_toDoItem);
        }

        private void GivenAToDoItemWithNoDescription()
        {
            _toDoItem = new ToDoItem();
            _toDoItem.Description = "";
        }
    }
}
