using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.Username)
                .HasColumnType("varchar(50)")
                .HasColumnName("username")
                .IsRequired();

            builder.Property(e => e.Role)
                .HasColumnType("varchar(100)")
                .HasColumnName("role")
                .IsRequired();

            builder.Property(e => e.Password)
                .HasColumnType("varchar(32)")
                .HasColumnName("password")
                .IsRequired();
        }
    }
}
