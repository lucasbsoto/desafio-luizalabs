using LuizaLabs.Domain.User;
using LuizaLabs.Service.User.Dtos;
using System.Threading.Tasks;

namespace LuizaLabs.Service.User
{
    public interface IUserService
    {
        Task<UserResponseDto> Add(UserRegisterRequestDto user);
        Task Update(UserPutRequestDto user);
        Task<UserResponseDto> GetById(int id);
        Task<UserTokenResponseDto> Login(UserLoginRequestDto user);
        Task ResetPassword(string email);
    }
}
