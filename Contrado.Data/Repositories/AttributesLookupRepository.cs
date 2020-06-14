using Contrado.Core.Models;
using Contrado.Core.Repositories;
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

        public ProductAttributeLookup GetById(int lookupId)
        {
            return _dbContext.ProductAttributeLookups.Find(lookupId);
        }

        public void Remove(ProductAttributeLookup attributeLookup)
        {
            _dbContext.ProductAttributeLookups.Remove(attributeLookup);
        }
    }
}
