using System.ComponentModel.DataAnnotations;

namespace LuizaLabs.Service.User.Dtos
{
    public class UserPutRequestDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
