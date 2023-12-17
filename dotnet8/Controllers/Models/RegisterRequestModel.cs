using System.ComponentModel.DataAnnotations;

namespace TodoApi.Controllers.Models
{
    public class RegisterRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
