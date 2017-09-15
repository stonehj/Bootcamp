namespace Asos.MiniProject.ToDo.Backend.Api.Controllers
{
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;

    public class ToDoController : ApiController
    {
        private readonly IToDoItemDataStore _toDoItemDataStore;

        public ToDoController(IToDoItemDataStore toDoItemDataStore)
        {
            _toDoItemDataStore = toDoItemDataStore;
        }
        
        public IHttpActionResult GetItems()
        {
            return this.Ok();
        }      
    }
}
