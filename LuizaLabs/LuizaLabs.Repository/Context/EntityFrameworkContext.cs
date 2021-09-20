using LuizaLabs.Domain;
using LuizaLabs.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Repository.Context
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options)
            : base(options) {}

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoUsuario());
        }
    }
}
