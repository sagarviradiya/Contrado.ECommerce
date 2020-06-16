using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsWithPaging(int page = 1, int pageSize = 10, bool includeNavigation= true);
        Product GetProductById(int productId, bool includeNavigation= true);
        void RemoveProduct(Product product);
        Product AddProduct(Product product);
        void UpdateProduct(Product productToUpdate);
    }
}
