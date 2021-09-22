using System.ComponentModel.DataAnnotations;

namespace LuizaLabs.Service.User.Dtos
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
