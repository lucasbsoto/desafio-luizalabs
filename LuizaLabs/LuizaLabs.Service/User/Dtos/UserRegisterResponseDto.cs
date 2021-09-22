using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Service.User.Dtos
{
    public class UserRegisterResponseDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }
}
