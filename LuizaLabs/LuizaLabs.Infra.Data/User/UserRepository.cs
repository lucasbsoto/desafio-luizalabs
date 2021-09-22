using LuizaLabs.Domain.User;
using LuizaLabs.Infra.Data.Base;
using LuizaLabs.Infra.Data.Context;

namespace LuizaLabs.Infra.Data.User
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(EntityFrameworkContext context) : base(context) { }
    }
}
