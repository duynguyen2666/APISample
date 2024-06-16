using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");


            builder.Property(e => e.CreateAt)
                .HasColumnName("create_at")
                .IsRequired();

            builder.Property(e => e.Total)
                .HasColumnType("int")
                .HasColumnName("total");
        }
    }
}
