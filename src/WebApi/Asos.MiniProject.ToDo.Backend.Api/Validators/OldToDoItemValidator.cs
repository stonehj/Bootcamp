namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    using System;
    using System.Collections.Generic;

    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public class OldToDoItemValidator
    {
        public string Validate(ToDoItem toDoItem)
        {
            List<string> errorList = new List<string>();
            
            if (toDoItem.Description == string.Empty)
            {
                errorList.Add("missing description");
            }

            if (toDoItem.DueBy.Date < DateTime.Now.Date)
            {
                errorList.Add("due by date cannot be in the past");
            }
            
            if (toDoItem.DateAdded.Date > DateTime.Now.Date)
            {
                errorList.Add("date added cannot be in the future");
            }

            if (toDoItem.DueBy.Date < toDoItem.DateAdded.Date)
            {
                errorList.Add("due by date cannot be before date added");
            }

            return string.Join(Environment.NewLine, errorList);
        }
    }
}