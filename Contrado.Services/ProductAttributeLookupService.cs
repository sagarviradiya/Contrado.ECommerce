using System.Collections.Generic;
using Contrado.Core;
using Contrado.Core.Models;
using Contrado.Core.Services;

namespace Contrado.Services
{
    public class ProductAttributeLookupService : IProductAttributeLookupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductAttributeLookupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Add(ProductAttributeLookup attributeLookup)
        {
            _unitOfWork.AttributesRepo.Add(attributeLookup);
            return _unitOfWork.Commit();
        }

        public IEnumerable<ProductAttributeLookup> GetAll(int categoryId = 0)
        {
            var attributes = _unitOfWork.AttributesRepo.GetAll(categoryId);
            return attributes;
        }

        public void Remove(ProductAttributeLookup attributeLookup)
        {
            _unitOfWork.AttributesRepo.Remove(attributeLookup);
            _unitOfWork.Commit();
        }
        public int Update(ProductAttributeLookup attributeLookup)
        {
            _unitOfWork.AttributesRepo.Update(attributeLookup);
            return _unitOfWork.Commit();
        }
    }
}