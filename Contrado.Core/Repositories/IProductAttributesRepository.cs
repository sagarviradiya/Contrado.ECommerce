using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Repositories
{
   public interface IProductAttributesRepository
    {
        void Add(ProductAttribute productAttribute);
        IEnumerable<ProductAttribute> GetByProductId(int productId,int attributeId=0);
        void Remove(ProductAttribute productAttribute);
       

    }
}
