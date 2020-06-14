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
    public class ProductAttributeLookupsConfiguration : IEntityTypeConfiguration<ProductAttributeLookup>
    {


        public void Configure(EntityTypeBuilder<ProductAttributeLookup> builder)
        {
            builder.HasKey(e => e.AttributeId);

            builder.Property(e => e.AttributeName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.HasOne(d => d.ProductCategory)
                   .WithMany(p => p.ProductAttributeLookup)
                   .HasForeignKey(d => d.ProdCatId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_ProductAttributeLookup_ProductCategory");
            builder.ToTable("ProductAttributeLookup");
        }
    }
}
