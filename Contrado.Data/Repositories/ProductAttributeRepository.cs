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


        public IEnumerable<ProductAttribute> GetByProductId(int productId, int attributeId = 0)
        {
            return _dbContext.ProductAttributes.Where(p => p.ProductId == productId);

        }

        public void Remove(ProductAttribute productAttribute)
        {
            _dbContext.ProductAttributes.Remove(productAttribute);
        }
    }
}
