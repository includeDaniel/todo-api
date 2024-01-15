namespace Todo.API.Controllers.Models
{
    public class TodoViewModel
    {
        public string? UserId { get; set; }
        public string Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
