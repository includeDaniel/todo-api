using Microsoft.AspNetCore.Identity;

namespace TodoApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<TodoItem>? TodoItems { get; set; }
    }
}
