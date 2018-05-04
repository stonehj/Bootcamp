﻿using System;
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
        private string message;

        [Test]
        public void ValidateToDoItemDescription()
        {
            this.Given(_ => this.GivenAToDoItemWithNoDescription())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnMissingDescriptionMessage())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemDueBy()
        {
            this.Given(_ => this.GivenAToDoItemWithDueByInThePast())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnDueByCannotBeInThePastMessage())
                .BDDfy();
        }

        [Test]
        public void ValidateToDoItemDateAdded()
        {
            this.Given(_ => this.GivenAToDoItemWithDateAddedInTheFuture())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnDateAddedCannotBeInTheFutureMessage())
                .BDDfy();
        }

        /*[Test]
        public void ValidateToDoItemDueByIsBeforeDateAdded()
        {
            this.Given(_ => this.GivenAToDoItemWithDueByBeforeDateAdded())
                .When(_ => WhenValidatingAToDoItem())
                .Then(_ => ThenReturnDueByDateCannotBeBeforeDateAddedMessage())
                .BDDfy();
        }*/

        /*private void ThenReturnDueByDateCannotBeBeforeDateAddedMessage()
        {
            message.ShouldBeEqualTo("due by date cannot be before date added");
        }*/

        private void ThenReturnDueByCannotBeInThePastMessage()
        {
            message.ShouldBeEqualTo("due by date cannot be in the past");
        }

        private void ThenReturnMissingDescriptionMessage()
        {
            message.ShouldBeEqualTo("missing description");
        }

        private void ThenReturnDateAddedCannotBeInTheFutureMessage()
        {
            message.ShouldBeEqualTo("date added cannot be in the future");
        }

        private void GivenAToDoItemWithDueByBeforeDateAdded()
        {
            CreateStandardToDoItem();
            _toDoItem.DueBy = DateTime.Now.AddDays(-5);
            _toDoItem.DateAdded = DateTime.Now.AddDays(-2);
        }

        public void GivenAToDoItemWithDateAddedInTheFuture()
        {
            CreateStandardToDoItem();
            _toDoItem.DateAdded = DateTime.Now.AddDays(7);
        }

        private void CreateStandardToDoItem()
        {
            _toDoItem = new ToDoItem
            {
                Description = "description",
                DueBy = DateTime.Now.AddDays(1),
                DateAdded = DateTime.Now
            };
        }

        private void GivenAToDoItemWithDueByInThePast()
        {
            CreateStandardToDoItem();
            _toDoItem.DueBy = DateTime.MinValue;
        }

        private void WhenValidatingAToDoItem()
        {
            var toDoItemValidator = new ToDoItemValidator();
            message = toDoItemValidator.Validate(_toDoItem);
        }

        private void GivenAToDoItemWithNoDescription()
        {
            CreateStandardToDoItem();
            _toDoItem.Description = "";
        }
    }
}
