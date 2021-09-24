using AutoMapper;
using LuizaLabs.Domain.User;
using LuizaLabs.Infra.Data.User;
using LuizaLabs.Service.Email;
using LuizaLabs.Service.User.Dtos;
using LuizaLabs.Shared.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabs.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository, 
                           IEmailService emailService, 
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Add(UserRegisterRequestDto userRequest)
        {
            var userModel = _mapper.Map<UserModel>(userRequest);
            if (!userModel.IsValid())
                throw new ArgumentException("Usuário inválido");

            var userExists = (await _userRepository.GetByFilters(p => p.Email == userModel.Email)).Any();

            if (userExists)
                throw new ArgumentException("Usuário já cadastrado");
            
            var userAdded = await _userRepository.Add(userModel);
            return _mapper.Map<UserResponseDto>(userAdded);
        }

        public async Task<UserResponseDto> GetById(int id)
        {
            var userExists = await _userRepository.GetByFilters(p => p.Id == id);

            if (userExists is null)
                throw new ArgumentNullException("Usuario não encontrado");

            return _mapper.Map<UserResponseDto>(userExists.FirstOrDefault());
        }

        public async Task<UserTokenResponseDto> Login(UserLoginRequestDto user)
        {
            var result = (await _userRepository.GetByFilters(p => p.Email == user.Email && p.Password == StringExtensions.EncryptPassword(user.Password))).FirstOrDefault();
            if (result is null)
                throw new ArgumentException("Usuario e/ou senha inválidos");

            var jwtToken = JwtExtensions.GenerateJwtToken(result.Id.ToString(), result.Email);

            return new UserTokenResponseDto(result.Id, result.Name, jwtToken.Item1, jwtToken.Item2);
        }

        public async Task Update(UserPutRequestDto userUpdate)
        {
            var userModel = _mapper.Map<UserModel>(userUpdate);
            if (!userModel.IsValid())
                throw new ArgumentException("Usuario inválido");

            var userExists = (await _userRepository.GetByFilters(p => p.Email == userModel.Email)).Any();

            if (!userExists)
                throw new ArgumentNullException("Usuário não encontrado");

            await _userRepository.Update(userModel);
        }

        public async Task ResetPassword(string email)
        {
            var userExists = await _userRepository.GetByFilters(x => x.Email == email);

            if (!userExists.Any())
                throw new Exception("Usuario não encontrado");

            await _emailService.SendPasswordChange(userExists.FirstOrDefault());
        }
    }
}
