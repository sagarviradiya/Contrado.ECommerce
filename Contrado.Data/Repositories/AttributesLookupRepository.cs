using System.Collections.Generic;
using System.Linq;
using Contrado.Core.Models;
using Contrado.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contrado.Data.Repositories
{
    public class AttributesLookupRepository : IAttributesLookupRepository
    {
        public readonly ECommerceDBContext _dbContext;
        public AttributesLookupRepository(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ProductAttributeLookup attributeLookup)
        {
            _dbContext.ProductAttributeLookups.Add(attributeLookup);
        }

        public IEnumerable<ProductAttributeLookup> GetAll(int categoryId = 0)
        {
            if (categoryId != 0)
                return _dbContext.ProductAttributeLookups.Include(a=>a.ProductAttributes).Where(i => i.ProdCatId == categoryId).ToList();
            return _dbContext.ProductAttributeLookups.ToList();
        }

        public void Remove(ProductAttributeLookup attributeLookup)
        {
            _dbContext.ProductAttributeLookups.Remove(attributeLookup);
        }
        public void Update(ProductAttributeLookup attributeLookup)
        {
            _dbContext.Entry(attributeLookup).State = EntityState.Modified;
        }
    }
}
