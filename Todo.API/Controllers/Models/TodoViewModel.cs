namespace Todo.API.Controllers.Models
{
    public class TodoViewModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
