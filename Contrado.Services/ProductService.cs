using Contrado.Core;
using Contrado.Core.Models;
using Contrado.Core.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Contrado.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Product AddProduct(Product product)
        {
            _unitOfWork.ProductRepo.AddProduct(product);
            _unitOfWork.Commit();
            return product;
        }

        public Product GetProductById(int productId)
        {
            return _unitOfWork.ProductRepo.GetProduct(productId, true);
        }

        public IEnumerable<Product> GetProductsWithPaging(int page = 1, int pageSize = 10)
        {
            return _unitOfWork.ProductRepo.GetProducts(page, pageSize);
        }

        public void RemoveProduct(Product product)
        {
            _unitOfWork.ProductRepo.Remove(product);
            _unitOfWork.Commit();

        }
        public void UpdateProduct(Product productToUpdate, Product product)
        {
            productToUpdate.ProdCatId = product.ProdCatId;
            productToUpdate.ProdName = product.ProdName;
            productToUpdate.ProdDescription = product.ProdDescription;
            productToUpdate.ProductCategory = product.ProductCategory;
            productToUpdate.ProductAttributes = product.ProductAttributes;

            _unitOfWork.Commit();
        }

    }
}
