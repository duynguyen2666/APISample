using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("product_categories", "dbo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(100)")
                .IsRequired();
        }
    }
}
