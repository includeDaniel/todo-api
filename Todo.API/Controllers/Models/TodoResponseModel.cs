using System.ComponentModel.DataAnnotations;

namespace Todo.API.Controllers.Models
{
    public class TodoResponseModel
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}
