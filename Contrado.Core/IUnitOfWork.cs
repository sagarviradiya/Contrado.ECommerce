using Contrado.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepo{ get; }
        IProductCategoryRepository ProductCategoryRepo{ get; }
        IProductAttributesRepository ProductAttributesRepo { get; }
        IAttributesLookupRepository AttributesRepo { get; }
        int Commit();
    }
}
