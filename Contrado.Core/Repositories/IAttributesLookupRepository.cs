using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Repositories
{
   public interface IAttributesLookupRepository
    {
        ProductAttributeLookup GetById(int lookupId);
        void Add(ProductAttributeLookup productAttribute);
        void Remove(ProductAttributeLookup productAttribute);
    }
}
