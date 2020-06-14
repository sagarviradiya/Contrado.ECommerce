using Contrado.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contrado.Data.Configurations
{
    class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(e => e.ProdCatId);

            builder.Property(e => e.CategoryName)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.ToTable("ProductCategory");

        }
    }
}
