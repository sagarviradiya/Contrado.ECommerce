using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contrado.Api.Dtos
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }

        public  ProductCategoryDto ProductCategory { get; set; }
    }
}
