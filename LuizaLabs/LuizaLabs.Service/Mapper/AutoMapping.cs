using AutoMapper;
using LuizaLabs.Domain.User;
using LuizaLabs.Service.User.Dtos;
using LuizaLabs.Shared.Extensions;

namespace LuizaLabs.Service.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<UserRegisterRequestDto, UserModel>()
                .ForMember(a => a.Password, d => d.MapFrom(s => StringExtensions.EncryptPassword(s.Password)));

            CreateMap<UserModel, UserResponseDto>();

            CreateMap<UserPutRequestDto, UserModel>()
                .ForMember(a => a.Password, d => d.MapFrom(s => StringExtensions.EncryptPassword(s.Password)));
        }
    }
}
