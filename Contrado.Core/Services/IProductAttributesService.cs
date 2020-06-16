using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Services
{
    public interface IProductAttributesService
    {
        IEnumerable<ProductAttribute> GetAll(int attributeId = 0);
        void Remove(ProductAttribute productAttribute);
        void Add(ProductAttribute productAttribute);
    }
}
