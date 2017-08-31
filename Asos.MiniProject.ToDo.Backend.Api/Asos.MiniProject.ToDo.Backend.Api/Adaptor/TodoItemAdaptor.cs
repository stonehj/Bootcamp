namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System;
    using System.Collections.Generic;

    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public class ToDoItemAdaptor : IToDoItemAdaptor
    {
        public IEnumerable<ToDoItem> GetAllItemsForUser(Guid userId)
        {
            throw new NotImplementedException("We need to write some code :)");
        }
    }
}