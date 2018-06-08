namespace Asos.MiniProject.ToDo.Backend.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using Asos.MiniProject.ToDo.Backend.Api.Models;

    using Microsoft.ApplicationInsights;

    [Route("ToDo")]
    public class ToDoController : ApiController
    {
        private readonly IToDoItemDataStore toDoItemDataStore;
        private readonly TelemetryClient telemetry = new TelemetryClient();

        public ToDoController(IToDoItemDataStore toDoItemDataStore)
        {
            this.toDoItemDataStore = toDoItemDataStore;
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetItems()
        {
            var items = await this.toDoItemDataStore.GetAllItemsAsync();
            return this.Ok(items);
        }

        [Route("todo/error")]
        [HttpGet]
        public IHttpActionResult AlwaysError()
        {
            try
            {
                throw new Exception("Helens Exception");
            }
            catch (Exception ex)
            {
                this.telemetry.TrackException(ex);
            }

            return this.Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetItem([FromUri]string id)
        {
            var item = await this.toDoItemDataStore.GetOneItem(id);
            return this.Ok(item);
        }

        [HttpPost]
        public async Task <IHttpActionResult> AddOneItem(ToDoItem item)
        {
            await this.toDoItemDataStore.AddOneItem(item);
            this.telemetry.TrackEvent("AddedItem");
            return this.Ok();
        }

        [HttpPatch]
        public async Task<IHttpActionResult> AmendExistingItem(ToDoItem item)
        {
            await this.toDoItemDataStore.AmendExistingItem(item);
            return this.Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOneItem(ToDoItem item)
        {
            await this.toDoItemDataStore.DeleteExistingItem(item);
            return this.Ok();
        }
    }
}
