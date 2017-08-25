namespace Asos.MiniProject.ToDo.Api.Models
{
    using System;

    public class ToDoItem
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Description { get; set; }

        public DateTime DueBy { get; set; }

        public DateTime DateAdded { get; set; }

        public bool Completed { get; set; }
    }
}