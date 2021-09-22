using LuizaLabs.Domain.User;
using LuizaLabs.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Infra.Data.User
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
    }
}
