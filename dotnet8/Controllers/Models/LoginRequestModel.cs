using System.ComponentModel.DataAnnotations;

namespace TodoApi.Controllers.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
