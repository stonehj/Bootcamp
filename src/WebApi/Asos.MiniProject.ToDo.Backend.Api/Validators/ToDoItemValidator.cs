using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asos.MiniProject.ToDo.Backend.Api.Models;

namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    public class ToDoItemValidator
    {
        public string errorMessage;

        public string Validate(ToDoItem toDoItem)
        {
            if (toDoItem.Description == "")
            {
               errorMessage = "missing description";
            }

            /*if (toDoItem.DueBy.Date < toDoItem.DateAdded.Date)
            {
                errorMessage = "due by date cannot be before date added";
            }*/

            if (toDoItem.DueBy.Date < DateTime.Now.Date)
            {
                errorMessage = "due by date cannot be in the past";
            }
            
            if (toDoItem.DateAdded.Date > DateTime.Now.Date)
            {
                errorMessage = "date added cannot be in the future";
            }
            return errorMessage;
        }
    }
}