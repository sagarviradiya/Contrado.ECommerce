using Contrado.Core;
using Contrado.Core.Repositories;
using Contrado.Data.Repositories;

namespace Contrado.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepo;
        private IProductCategoryRepository _productCategoryRepo;
        private IProductAttributesRepository _productAttributesRepo;
        private IAttributesLookupRepository _attributesRepo;
        private readonly ECommerceDBContext _dbContext;

        public IProductRepository ProductRepo => _productRepo ?? new ProductRepository(_dbContext);
        public IProductCategoryRepository ProductCategoryRepo => _productCategoryRepo ?? new ProductCategoryRepository(_dbContext);
        public IProductAttributesRepository ProductAttributesRepo => _productAttributesRepo ?? new ProductAttributeRepository(_dbContext);
        public IAttributesLookupRepository AttributesRepo => _attributesRepo ?? new AttributesLookupRepository(_dbContext);

        public UnitOfWork(ECommerceDBContext context)
        {
            this._dbContext = context;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
