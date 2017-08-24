namespace Asos.MiniProject.ToDo.Api.Controllers
{
    using System.Web.Http;

    [RoutePrefix("todo/items")]
    public class ToDoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            return this.Ok();
        }
    }
}
