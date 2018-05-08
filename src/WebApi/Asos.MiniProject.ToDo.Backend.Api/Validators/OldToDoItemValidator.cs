using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Asos.MiniProject.ToDo.Backend.Api.Models;

namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    public class OldToDoItemValidator
    {
        public string Validate(ToDoItem toDoItem)
        {
            List<string> errorList = new List<string>();
            
            if (toDoItem.Description == "")
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

            return String.Join(Environment.NewLine, errorList);
        }
    }
}