namespace Todo.Business.Models 
{ 
    public class TodoModel : Entity
    {
        public  string? UserId { get; set; }
        public  string? Name { get; set; }
        public bool IsComplete { get; set; }   
        public  ApplicationUser? ApplicationUser { get; set; }
    }
}