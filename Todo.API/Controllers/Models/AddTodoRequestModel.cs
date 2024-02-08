using System.ComponentModel.DataAnnotations;

namespace Todo.API.Controllers.Models
{
    public class AddTodoRequestModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
