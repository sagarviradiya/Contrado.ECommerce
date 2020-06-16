using Contrado.Core.Models;
using Contrado.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Contrado.Data.Repositories
{
    public class ProductAttributeRepository : IProductAttributesRepository
    {
        public readonly ECommerceDBContext _dbContext;
        public ProductAttributeRepository(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ProductAttribute productAttribute)
        {
            _dbContext.ProductAttributes.Add(productAttribute);
        }


        public IEnumerable<ProductAttribute> GetAll(int attributeId = 0)
        {
            if(attributeId!=0)
            return _dbContext.ProductAttributes.Where(p => p.AttributeId == attributeId);
            
            return _dbContext.ProductAttributes.ToList();
        }

        public void Remove(ProductAttribute productAttribute)
        {
            _dbContext.ProductAttributes.Remove(productAttribute);
        }
    }
}
