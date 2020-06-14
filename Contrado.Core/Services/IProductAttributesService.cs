using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Services
{
    public interface IProductAttributesService
    {
        IEnumerable<ProductAttribute> Get(int productId,int attributeId=0);
        void Remove(ProductAttribute productAttribute);
        void Add(ProductAttribute productAttribute);
    }
}
