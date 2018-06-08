namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public class ToDoItemValidator

    {
        private readonly ToDoItemFluentValidator toDoItemValidator;

        public ToDoItemValidator()
        {
            this.toDoItemValidator = new ToDoItemFluentValidator();

        }

        public string Validate(ToDoItem toDoItem)
        {
            var errors = this.toDoItemValidator.Validate(toDoItem).Errors;
            string message = null;
            foreach (var error in errors)
            {
                message += error.ErrorMessage;
            }

            return message;
        }

    }
}