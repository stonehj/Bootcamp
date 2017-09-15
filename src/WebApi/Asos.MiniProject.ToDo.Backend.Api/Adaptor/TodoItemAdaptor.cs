namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public class ToDoItemAdaptor : IToDoItemAdaptor
    {
        public Task<IEnumerable<ToDoItem>> GetAllItemsAsync()
        {
            throw new NotImplementedException("We need to write some code :)");
        }
    }
}