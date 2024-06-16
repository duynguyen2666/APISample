using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("order_details");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(e => e.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .HasColumnType("int");

            builder.HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId);
        }
    }
}
