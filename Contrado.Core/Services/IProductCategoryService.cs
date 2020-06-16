using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetCategories();
        ProductCategory GetCategoryById(int categoryId);
    }
}
