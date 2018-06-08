namespace Asos.MiniProject.ToDo.Backend.Api.UnitTests.Controllers
{
    using System;

    using Asos.MiniProject.ToDo.Backend.Api.Models;
    using Asos.MiniProject.ToDo.Backend.Api.Validators;

    using FluentAssert;

    using NUnit.Framework;

    using TestStack.BDDfy;

    public class ToDoItemValidatorShould
    {
        private ToDoItem _toDoItem;
        private bool result;
        private string message;

        [Test]
        public void ValidateToDoItemDescription()
        {
            this.Given(_ => this.GivenAToDoItemWithNoDescription())
                .When(_ => this.WhenValidatingAToDoItem())
                .Then(_ => this.ThenReturnMissingDescriptionMessage())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemDueBy()
        {
            this.Given(_ => this.GivenAToDoItemWithDueByInThePast())
                .When(_ => this.WhenValidatingAToDoItem())
                .Then(_ => this.ThenReturnDueByCannotBeInThePastMessage())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemDateAdded()
        {
            this.Given(_ => this.GivenAToDoItemWithDateAddedInTheFuture())
                .When(_ => this.WhenValidatingAToDoItem())
                .Then(_ => this.ThenReturnDateAddedCannotBeInTheFutureMessage())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemDueByIsBeforeDateAdded()
        {
            this.Given(_ => this.GivenAToDoItemWithDueByBeforeDateAdded())
                .When(_ => this.WhenValidatingAToDoItem())
                .Then(_ => this.ThenReturnDueByDateCannotBeBeforeDateAddedMessage())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemWhenItHasMoreThanOneError()
        {
            this.Given(_ => this.GivenAToDoItemWithNoDescriptionAndDueByInThePast())
                .When(_ => this.WhenValidatingAToDoItem())
                .Then(_ => this.ThenBothErrorMessagesReturned())
                .BDDfy();
        }

        private void ThenBothErrorMessagesReturned()
        {
            message.ShouldContain("due by date cannot be in the past");
            message.ShouldContain("missing description");
        }

        private void GivenAToDoItemWithNoDescriptionAndDueByInThePast()
        {
            this.CreateStandardToDoItem();
            this._toDoItem.DueBy = DateTime.MinValue;
            this._toDoItem.Description = string.Empty;
        }

        private void ThenReturnDueByDateCannotBeBeforeDateAddedMessage()
        {
            this.message.ShouldContain("due by date cannot be before date added");
        }

        private void ThenReturnDueByCannotBeInThePastMessage()
        {
            this.message.ShouldContain("due by date cannot be in the past");
        }

        private void ThenReturnMissingDescriptionMessage()
        {
            this.message.ShouldContain("missing description");
        }

        private void ThenReturnDateAddedCannotBeInTheFutureMessage()
        {
            this.message.ShouldContain("date added cannot be in the future");
        }

        private void GivenAToDoItemWithDueByBeforeDateAdded()
        {
            this.CreateStandardToDoItem();
            this._toDoItem.DueBy = DateTime.Now.AddDays(-5);
            this._toDoItem.DateAdded = DateTime.Now.AddDays(-2);
        }

        private void GivenAToDoItemWithDateAddedInTheFuture()
        {
            this.CreateStandardToDoItem();
            this._toDoItem.DateAdded = DateTime.Now.AddDays(7);
        }

        private void CreateStandardToDoItem()
        {
            this._toDoItem = new ToDoItem
            {
                Description = "description",
                DueBy = DateTime.Now.AddDays(1),
                DateAdded = DateTime.Now.AddDays(-1)
            };
        }

        private void GivenAToDoItemWithDueByInThePast()
        {
            this.CreateStandardToDoItem();
            this._toDoItem.DueBy = DateTime.MinValue;
        }

        private void WhenValidatingAToDoItem()
        {
            var toDoItemValidator = new ToDoItemValidator();
            this.message = toDoItemValidator.Validate(this._toDoItem);
        }

        private void GivenAToDoItemWithNoDescription()
        {
            this.CreateStandardToDoItem();
            this._toDoItem.Description = string.Empty;
        }
    }
}
