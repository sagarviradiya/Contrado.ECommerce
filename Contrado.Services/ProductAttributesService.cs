using Contrado.Core;
using Contrado.Core.Models;
using Contrado.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrado.Services
{
    public class ProductAttributesService : IProductAttributesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductAttributesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(ProductAttribute productAttribute)
        {
            _unitOfWork.ProductAttributesRepo.Add(productAttribute);
            _unitOfWork.Commit();
        }

        public IEnumerable<ProductAttribute> Get(int productId, int attributeId = 0)
        {
            var attributes = _unitOfWork.ProductAttributesRepo.GetByProductId(productId, attributeId);
            _unitOfWork.Commit();
            return attributes;
        }

        public void Remove(ProductAttribute productAttribute)
        {
            _unitOfWork.ProductAttributesRepo.Remove(productAttribute);
            _unitOfWork.Commit();
        }
    }
}
