using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asos.MiniProject.ToDo.Backend.Api.Models;

namespace Asos.MiniProject.ToDo.Backend.Api.Validators
{
    public class ToDoItemValidator
    {
        public bool Validate(ToDoItem toDoItem)
        {
            if (toDoItem.Description == "")
            {
                return false;
            }

            return true;
        }
    }
}