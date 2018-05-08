using System;
using System.Linq;
using System.Web.Services.Description;
using Asos.MiniProject.ToDo.Backend.Api.Models;
using FluentValidation;
using Microsoft.Azure.Documents.SystemFunctions;

namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    public class ToDoItemFluentValidator : AbstractValidator<ToDoItem>
    {
        public ToDoItemFluentValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("missing description");
            RuleFor(x => x.DueBy)
                .GreaterThan(DateTime.Today).WithMessage("due by date cannot be in the past")
                .GreaterThan(x => x.DateAdded).WithMessage("due by date cannot be before date added");
            RuleFor(x => x.DateAdded)
                .LessThan(DateTime.Today).WithMessage("date added cannot be in the future");
            
        }

    }
}