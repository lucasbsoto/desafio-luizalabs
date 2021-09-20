using LuizaLabs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuizaLabs.Repository.Mapping
{
    public class MapeamentoUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(u => u.IdUsuario);
            builder.HasIndex(u => u.IdUsuario).IsUnique();

            builder.Property(e => e.IdUsuario).HasColumnName("ID");
            builder.Property(e => e.Nome).HasColumnName("NOME");
            builder.Property(e => e.Email).HasColumnName("EMAIL");
            builder.Property(e => e.Senha).HasColumnName("SENHA");
        }
    }
}
