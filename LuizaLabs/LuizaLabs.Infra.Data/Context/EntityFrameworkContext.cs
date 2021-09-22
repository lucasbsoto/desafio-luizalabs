using LuizaLabs.Domain;
using LuizaLabs.Domain.User;
using LuizaLabs.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Infra.Data.Context
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options)
            : base(options) {}

        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
