using Microsoft.AspNetCore.Identity;

namespace Todo.Business.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<TodoModel>? Todos { get; set; }
    }
}
