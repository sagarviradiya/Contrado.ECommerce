using Contrado.Core.Models;
using System.Collections.Generic;

namespace Contrado.Core.Repositories
{
    public interface IProductCategoryRepository
    {
        ProductCategory GetById(int categoryId);
        void Add(ProductCategory category);
        void Remove(ProductCategory category);
        
    }
}
