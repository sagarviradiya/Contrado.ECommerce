using Contrado.Core.Models;
using Contrado.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Services
{
    public class ProductCategoryService: IProductCategoryService
    {
        IEnumerable<ProductCategory> IProductCategoryService.GetProductCategories(int productId)
        {
            throw new NotImplementedException();
        }

        void IProductCategoryService.RemoveProductCategories(int productId, int categoryId)
        {
            throw new NotImplementedException();
        }

        void IProductCategoryService.AddProductCategory(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        void IProductCategoryService.AssignCategoryToProduct(int productId, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
