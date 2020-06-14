﻿using Contrado.Core.Models;
using Contrado.Core.Repositories;
using System.Linq;

namespace Contrado.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ECommerceDBContext _dbContext;
        public ProductCategoryRepository(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ProductCategory category)
        {
            _dbContext.ProductCategories.Add(category);
        }
        public ProductCategory GetById(int categoryId)
        {
            return _dbContext.ProductCategories.SingleOrDefault(p => p.ProdCatId == categoryId);
        }

        public void Remove(ProductCategory category)
        {
            _dbContext.ProductCategories.Remove(category);
        }
    }
}
