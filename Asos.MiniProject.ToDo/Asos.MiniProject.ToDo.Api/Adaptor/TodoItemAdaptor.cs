namespace Asos.MiniProject.ToDo.Api.Adaptor
{
    using System;
    using System.Collections.Generic;
    using Asos.MiniProject.ToDo.Api.Models;

    public class ToDoItemAdaptor : IToDoItemAdaptor
    {
        public IEnumerable<ToDoItem> GetAllItemsForUser(Guid userId)
        {
            throw new NotImplementedException("We need to write some code :)");
        }
    }
}