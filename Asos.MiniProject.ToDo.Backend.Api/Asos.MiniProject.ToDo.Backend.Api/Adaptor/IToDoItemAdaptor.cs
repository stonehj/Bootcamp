namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System.Collections.Generic;
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public interface IToDoItemAdaptor
    {
        IEnumerable<ToDoItem> GetAllItems();
    }
}