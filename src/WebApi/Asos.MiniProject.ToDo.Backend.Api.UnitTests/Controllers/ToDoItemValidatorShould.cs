using System;
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

        [Test]
        public void ValidateToDoItemDueBy()
        {
            this.Given(_ => this.GivenAToDoItemWithDueByInThePast())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnFalse())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemDateAdded()
        {
            this.Given(_ => this.GivenAToDoItemWithDateAddedInTheFuture())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnFalse())
                .BDDfy();
        }

        public void GivenAToDoItemWithDateAddedInTheFuture()
        {
            _toDoItem = new ToDoItem();
            _toDoItem.Description = "description";
            _toDoItem.DueBy = DateTime.Now;
            _toDoItem.DateAdded = DateTime.Now.AddDays(1);
        }

        private void GivenAToDoItemWithDueByInThePast()
        {
            _toDoItem = new ToDoItem();
            _toDoItem.Description = "description";
            _toDoItem.DueBy = DateTime.MinValue;
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
