using LuizaLabs.Domain.User;
using System.Threading.Tasks;

namespace LuizaLabs.Service.Email
{
    public interface IEmailService
    {
        Task SendPasswordChange(UserModel userModel);
    }
}
