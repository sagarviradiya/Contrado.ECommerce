using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Repositories
{
   public interface IAttributesLookupRepository
    {
        IEnumerable<ProductAttributeLookup> GetAll(int categoryId);
        void Add(ProductAttributeLookup productAttribute);
        void Remove(ProductAttributeLookup productAttribute);
        void Update(ProductAttributeLookup attributeLookup);
    }
}
