namespace Asos.MiniProject.ToDo.Backend.Api.Adaptor
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IToDoItemDataStore
    {
        Task<IEnumerable<ToDoItem>> GetAllItemsAsync();

        Task<ToDoItem> GetOneItem(string id);

        Task AddOneItem(ToDoItem item);

        Task AmendExistingItem(ToDoItem item);

        Task DeleteExistingItem(ToDoItem item);
    }
}