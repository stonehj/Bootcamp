namespace Asos.MiniProject.ToDo.Backend.Api.Controllers
{
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using System.Threading.Tasks;

    public class ToDoController : ApiController
    {
        private readonly IToDoItemDataStore _toDoItemDataStore;

        public ToDoController(IToDoItemDataStore toDoItemDataStore)
        {
            _toDoItemDataStore = toDoItemDataStore;
        }

        public async Task<IHttpActionResult> GetItems()
        {
            return this.Ok();
        }      
    }
}
