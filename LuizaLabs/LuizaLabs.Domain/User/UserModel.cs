using LuizaLabs.Domain.Base;
using LuizaLabs.Shared.Extensions;

namespace LuizaLabs.Domain.User
{
    public class UserModel : IEntity
    {
        public UserModel() {}

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(Name) && Name.Length <= 120)
                && (ValidationExtensions.EmailIsValid(Email))
                && (!string.IsNullOrEmpty(Password) && Password.Length <= 120);
        }
    }
}
