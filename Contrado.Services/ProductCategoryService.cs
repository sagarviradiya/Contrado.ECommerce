using Contrado.Core.Models;
using Contrado.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Contrado.Core;
namespace Contrado.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProductCategory> GetCategories()
        {
            return _unitOfWork.ProductCategoryRepo.GetCategories();
        }
        public ProductCategory GetCategoryById(int categoryId)
        {
            return _unitOfWork.ProductCategoryRepo.GetById(categoryId);
        }
        
    }
}
