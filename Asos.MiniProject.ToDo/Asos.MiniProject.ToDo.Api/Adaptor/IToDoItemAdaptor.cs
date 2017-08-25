namespace Asos.MiniProject.ToDo.Api.Adaptor
{
    using System;
    using System.Collections.Generic;
    using Asos.MiniProject.ToDo.Api.Models;

    public interface IToDoItemAdaptor
    {
        IEnumerable<ToDoItem> GetAllItemsForUser(Guid userId);
    }
}