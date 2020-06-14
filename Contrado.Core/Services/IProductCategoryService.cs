using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetProductCategories(int productId = 0);
        void RemoveProductCategories(int productId, int categoryId);
        void AddProductCategory(ProductCategory productCategory);
        void AssignCategoryToProduct(int productId, int categoryId);
    }
}
