namespace Asos.MiniProject.ToDo.Backend.Api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Models;
    using Swashbuckle.Swagger.Annotations;

    public class ToDoController : ApiController
    {
        private readonly IToDoItemAdaptor toDoItemAdaptor;

        public ToDoController(IToDoItemAdaptor toDoItemAdaptor)
        {
            this.toDoItemAdaptor = toDoItemAdaptor;
        }

        [Route("todo/items")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "Items", typeof(List<ToDoItem>))]
        public IHttpActionResult GetItems()
        {
            return this.Ok();
        }      
    }
}
