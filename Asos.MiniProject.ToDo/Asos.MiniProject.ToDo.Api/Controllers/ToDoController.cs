namespace Asos.MiniProject.ToDo.Api.Controllers
{
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Api.Adaptor;

    public class ToDoController : ApiController
    {
        private readonly IToDoItemAdaptor toDoItemAdaptor;

        public ToDoController(IToDoItemAdaptor toDoItemAdaptor)
        {
            this.toDoItemAdaptor = toDoItemAdaptor;
        }

        [Route("todo/items")]
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            return this.Ok();
        }
    }
}
