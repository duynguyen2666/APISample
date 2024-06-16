using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", "dbo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.CategoryId)
                .HasColumnName("category_id");

            builder.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
