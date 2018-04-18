﻿using Asos.MiniProject.ToDo.Backend.Api.Models;

namespace Asos.MiniProject.ToDo.Backend.Api.Controllers
{
    using System.Web.Http;
    using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
    using System.Threading.Tasks;

    [Route("ToDo")]
    public class ToDoController : ApiController
    {
        private readonly IToDoItemDataStore _toDoItemDataStore;

       
        public ToDoController(IToDoItemDataStore toDoItemDataStore)
        {
            _toDoItemDataStore = toDoItemDataStore;
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetItems()
        {
            var items = await _toDoItemDataStore.GetAllItemsAsync();
            return this.Ok(items);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetItem(int i)
        {
            var item = await _toDoItemDataStore.GetOneItem(i);
            return this.Ok(item);
        }

        [HttpPost]
        public async Task <IHttpActionResult> AddOneItem(ToDoItem item)
        {
            await _toDoItemDataStore.AddOneItem(item);
            return this.Ok();
        }

        [HttpPatch]
        public async Task<IHttpActionResult> AmendExistingItem(ToDoItem item)
        {
            await _toDoItemDataStore.AmendExistingItem(item);
            return this.Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOneItem(ToDoItem item)
        {
            await _toDoItemDataStore.DeleteExistingItem(item);
            return this.Ok();
        }
    }
}
