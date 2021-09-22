using AutoMapper;
using LuizaLabs.Domain.User;
using LuizaLabs.Service.User.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Service.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<UserRegisterRequestDto, UserModel>();
            CreateMap<UserModel, UserRegisterResponseDto>();

            CreateMap<UserPutRequestDto, UserModel>();
        }
    }
}
