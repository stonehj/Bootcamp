namespace Asos.MiniProject.ToDo.Backend.Api.Models
{
    using System;
    using Newtonsoft.Json;

    public class ToDoItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime DueBy { get; set; }

        public DateTime DateAdded { get; set; }

        public bool Completed { get; set; }
    }
}