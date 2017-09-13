namespace Asos.MiniProject.ToDo.Backend.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    public class ToDoController : ApiController
    {
        private readonly IToDoItemAdaptor toDoItemAdaptor;

        public ToDoController(IToDoItemAdaptor toDoItemAdaptor)
        {
            this.toDoItemAdaptor = toDoItemAdaptor;
        }

        [Route("todo/items")]
        [HttpGet]
        public async Task<IHttpActionResult> GetItems()
        {
            var items = await this.toDoItemAdaptor.GetAllItemsAsync();
            return this.Ok(items);
        }

        [Route("todo/items", Name = "CreateItem")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateItem([FromBody] ToDoItem toDoItem)
        {
            await this.toDoItemAdaptor.CreateItemAsync(toDoItem);
            return this.CreatedAtRoute("GetItem", new { id = toDoItem.Id }, toDoItem);
        }

        [Route("todo/items/{id}", Name = "GetItem")]
        [HttpGet]
        public Task<IHttpActionResult> GetItem([FromUri]string id)
        {
            throw new NotImplementedException("Implement in a later session.");
        }

        [Route("todo/items/{id}", Name = "UpdateItem")]
        [HttpPatch]
        public async Task UpdateItem([FromBody] ToDoItem toDoItem, [FromUri] string id)
        {
            await this.toDoItemAdaptor.UpdateItemAsync(id, toDoItem);
        }

        [Route("todo/items/{id}", Name = "DeleteItem")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItem([FromUri] string id)
        {
            await this.toDoItemAdaptor.DeleteItemAsync(id);
            return this.Ok();
        }
    }
}
