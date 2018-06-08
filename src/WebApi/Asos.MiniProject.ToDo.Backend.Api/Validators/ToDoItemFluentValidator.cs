namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    using System;

    using Asos.MiniProject.ToDo.Backend.Api.Models;

    using FluentValidation;

    public class ToDoItemFluentValidator : AbstractValidator<ToDoItem>
    {
        public ToDoItemFluentValidator()
        {
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("missing description");
            this.RuleFor(x => x.DueBy)
                .GreaterThan(DateTime.Today).WithMessage("due by date cannot be in the past")
                .GreaterThan(x => x.DateAdded).WithMessage("due by date cannot be before date added");
            this.RuleFor(x => x.DateAdded)
                .LessThan(DateTime.Today).WithMessage("date added cannot be in the future");
            
        }

    }
}