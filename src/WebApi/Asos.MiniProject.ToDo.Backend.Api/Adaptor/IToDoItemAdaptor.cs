namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public interface IToDoItemAdaptor
    {
        Task<IEnumerable<ToDoItem>> GetAllItemsAsync();

        Task CreateItemAsync(ToDoItem item);

        Task UpdateItemAsync(string id, ToDoItem item);

        Task DeleteItemAsync(string id);
    }
}