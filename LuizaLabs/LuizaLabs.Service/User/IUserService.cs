using LuizaLabs.Domain.User;
using LuizaLabs.Service.User.Dtos;
using System.Threading.Tasks;

namespace LuizaLabs.Service.User
{
    public interface IUserService
    {
        Task<UserRegisterResponseDto> Add(UserRegisterRequestDto user);
        Task<UserModel> Update(UserPutRequestDto user);
        Task<UserModel> GetById(int id);
        Task<UserTokenResponseDto> Login(UserLoginRequestDto user);
        Task<UserModel> ResetPassword(string email);
    }
}
