using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contrado.Api.Dtos;
using Contrado.Core.Models;
using Contrado.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contrado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;

        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll(int page = 1, int pagesize = 10)
        {
            //return Ok(_productService.GetProductsWithPaging());
            var products = _productService.GetProductsWithPaging();
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductForPostRequestDto>>(products));

        }
        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            //return Ok(_productService.GetProductsWithPaging());
            var product = _productService.GetProductById(productId);
            return Ok(_mapper.Map<Product, ProductDto>(product));
        }

        [HttpPost("createproduct")]
        public ActionResult<ProductForPostRequestDto> CreateProduct(ProductForPostRequestDto product)
        {
            var productDomain = _mapper.Map<ProductForPostRequestDto, Product>(product);
            var returnProduct = _productService.AddProduct(productDomain);

            // Save Attributes
            
            

            return Ok(_mapper.Map<Product, ProductForPostRequestDto>(returnProduct));
        }
    }
}
