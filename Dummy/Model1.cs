namespace Dummy
{
    using System.Data.Entity;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttributeLookup> ProductAttributeLookups { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.ProdName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProdDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductAttributes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductAttributeLookup>()
                .Property(e => e.AttributeName)
                .IsUnicode(false);

            modelBuilder.Entity<ProductAttributeLookup>()
                .HasMany(e => e.ProductAttributes)
                .WithRequired(e => e.ProductAttributeLookup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.ProductAttributeLookups)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductAttribute>()
                .Property(e => e.AttributeValue)
                .IsUnicode(false);
        }
    }
}
