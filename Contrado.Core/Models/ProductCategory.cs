using System;
using System.Collections.Generic;

namespace Contrado.Core.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
            ProductAttributeLookup = new HashSet<ProductAttributeLookup>();
        }

        public int ProdCatId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductAttributeLookup> ProductAttributeLookup { get; set; }
    }
}
