using LuizaLabs.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuizaLabs.Infra.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.Password).HasColumnName("Password");
        }
    }
}
