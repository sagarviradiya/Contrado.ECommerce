using Contrado.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contrado.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProdDescription)
                    .IsUnicode(false);


            builder.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            
            //Product(1)->ProductAttributes(*)
            builder.HasMany(d => d.ProductAttributes)
                   .WithOne(e => e.Product)
                   .HasForeignKey(s => s.AttributeId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            //Product(1)->ProductCategory(1)
            builder.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProdCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");

            builder.ToTable("Product");
        }
    }
}
