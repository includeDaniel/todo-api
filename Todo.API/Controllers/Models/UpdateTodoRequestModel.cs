namespace Todo.API.Controllers.Models
{
    public class UpdateTodoRequestModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public required string Name { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
