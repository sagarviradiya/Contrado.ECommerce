using System;
using System.Collections.Generic;

namespace Contrado.Core.Models
{
    public class ProductAttributeLookup
    {
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        public string AttributeName { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

    }
}
