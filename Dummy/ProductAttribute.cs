namespace Dummy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAttribute")]
    public partial class ProductAttribute
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeId { get; set; }

        [StringLength(250)]
        public string AttributeValue { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductAttributeLookup ProductAttributeLookup { get; set; }
    }
}
