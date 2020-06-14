using Contrado.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Data.Configurations
{
    public class ProductAttributesConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {

            builder.HasKey(sc => new { sc.AttributeId, sc.ProductId });

            builder.Property(e => e.AttributeValue)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.HasOne(d => d.AttributeLookup)
                .WithMany(e => e.ProductAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAttribute_ProductAttributeLookup");

            builder.HasOne(d => d.Product)
                .WithMany(pa=>pa.ProductAttributes)
                .HasForeignKey(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAttribute_Product");
            builder.ToTable("ProductAttribute");

        }
    }
}
