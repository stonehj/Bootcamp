namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public interface IToDoItemDataStore
    {
        Task<IEnumerable<ToDoItem>> GetAllItemsAsync();
        Task<ToDoItem> GetOneItem(int id);
        Task AddOneItem(ToDoItem item);
        Task AmendExistingItem(ToDoItem item);
        Task<ToDoItem> DeleteExistingItem(ToDoItem item);
    }
}