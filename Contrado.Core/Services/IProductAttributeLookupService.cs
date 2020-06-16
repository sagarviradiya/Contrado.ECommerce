using System.Collections.Generic;
using Contrado.Core.Models;

namespace Contrado.Core.Services
{
    public interface IProductAttributeLookupService
    {
         IEnumerable<ProductAttributeLookup> GetAll(int attributeId = 0);
        void Remove(ProductAttributeLookup productAttribute);
        int Add(ProductAttributeLookup productAttribute);
        int Update(ProductAttributeLookup attributeLookup);
    }
}