using Contrado.Core.Models;
using Contrado.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contrado.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDBContext _dbContext;
        public ProductRepository(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _dbContext.Products.Where(predicate);

        }

        public Product GetProduct(int productId, bool includeNavigation)
        {
            if (includeNavigation)
            {
                return _dbContext.Products
                   .Include(x => x.ProductCategory)
                .ThenInclude(s => s.ProductAttributeLookup)
                 .Include(a => a.ProductAttributes)
                 .Where(s => s.ProductId == productId).FirstOrDefault();
            }
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts(int page = 1, int pageSize = 10)
        {
            var pageCount = (double)_dbContext.Products.ToList().Count / pageSize;
            pageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            return _dbContext.Products
                .Include(x => x.ProductCategory)
                .ThenInclude(s => s.ProductAttributeLookup)
                 .Include(a => a.ProductAttributes)
                 .Skip(skip).Take(pageSize)
                    .ToList();
        }

        public void Remove(Product product)
        {
            _dbContext.Products.Remove(product);
        }
    }
}
