using System;
using System.Collections.Generic;

namespace Contrado.Core.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }


    }
}
