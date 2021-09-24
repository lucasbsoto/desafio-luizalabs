using System.ComponentModel.DataAnnotations;

namespace LuizaLabs.Service.User.Dtos
{
    public class UserPutRequestDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
