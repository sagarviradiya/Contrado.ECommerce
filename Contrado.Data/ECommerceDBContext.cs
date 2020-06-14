using Contrado.Core.Models;
using Microsoft.EntityFrameworkCore;
using Contrado.Data.Configuration;
using Contrado.Data.Configurations;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Contrado.Data
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeLookup> ProductAttributeLookups { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .ApplyConfiguration(new ProductConfiguration());

            builder
                .ApplyConfiguration(new ProductCategoryConfiguration());

            builder
                .ApplyConfiguration(new ProductAttributesConfiguration());

            builder
                .ApplyConfiguration(new ProductAttributeLookupsConfiguration());

        }
    }
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDBContext>
    //{
    //    public ECommerceDBContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Contrado.API/appsettings.json").Build();
    //        var builder = new DbContextOptionsBuilder<ECommerceDBContext>();
    //        var connectionString = configuration["Connections:ConnectionString"];
    //        builder.UseSqlServer(connectionString);
    //        return new ECommerceDBContext(builder.Options);
    //    }
    //}
}
