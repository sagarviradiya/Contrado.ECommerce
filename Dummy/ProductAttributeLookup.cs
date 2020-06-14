namespace Dummy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAttributeLookup")]
    public partial class ProductAttributeLookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductAttributeLookup()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        [Key]
        public int AttributeId { get; set; }

        public int ProdCatId { get; set; }

        [Required]
        [StringLength(250)]
        public string AttributeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
