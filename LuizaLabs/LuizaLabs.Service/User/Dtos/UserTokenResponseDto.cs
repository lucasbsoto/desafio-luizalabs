using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Service.User.Dtos
{
    public class UserTokenResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public UserTokenResponseDto(int id, string userName, string token, DateTime expireDate)
        {
            Id = id;
            UserName = userName;
            Token = token;
            ExpireDate = expireDate;
        }
    }
}
