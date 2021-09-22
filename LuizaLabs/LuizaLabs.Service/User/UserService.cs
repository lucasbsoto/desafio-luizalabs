using AutoMapper;
using LuizaLabs.Domain.User;
using LuizaLabs.Infra.Data.User;
using LuizaLabs.Service.User.Dtos;
using LuizaLabs.Shared.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserRegisterResponseDto> Add(UserRegisterRequestDto userRequest)
        {
            var user = _mapper.Map<UserModel>(userRequest);
            var added = await _userRepository.Add(user);
            return _mapper.Map<UserRegisterResponseDto>(added);
        }

        public async Task<UserModel> GetById(int id)
        {
            return (await _userRepository.GetByFilters(p => p.Id == id)).FirstOrDefault();
        }

        public async Task<UserTokenResponseDto> Login(UserLoginRequestDto user)
        {
            var result = (await _userRepository.GetByFilters(p => p.Email == user.Email && p.Password == user.Password)).FirstOrDefault();
            var jwtToken = JwtExtensions.GenerateJwtToken(result.Id.ToString(), result.Email);

            return new UserTokenResponseDto(result.Id, result.Name, jwtToken.Item1, jwtToken.Item2);
        }

        public async Task<UserModel> Update(UserPutRequestDto userUpdate)
        {
            var user = _mapper.Map<UserModel>(userUpdate);
            return await _userRepository.Update(user);
        }

        public async Task<UserModel> ResetPassword(string email)
        {
            var user = await _userRepository.GetByFilters(x => x.Email == email);

            //if (!user.Any())
            //    throw new ElementoNaoEncontratoException("Usuario não encontrado");

            //_servicoEmail.EnviaEmail(user.FirstOrDefault());

            return user.FirstOrDefault();
        }
    }
}
