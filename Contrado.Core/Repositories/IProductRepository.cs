using Contrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int page = 1, int pageSize = 10,bool includeNavigation = true);
        Product GetProduct(int productId, bool includeNavigation);
        IEnumerable<Product> Find(Func<Product, bool> predicate);
        void AddProduct(Product product);
        void Remove(Product product);
        void Update(Product product);
    }
}
