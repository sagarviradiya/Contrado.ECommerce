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
        [HttpGet("getall")]
        public ActionResult<IEnumerable<ProductDto>> GetAll(int page = 1, int pagesize = 10, bool includeNavigation = true)
        {
            var products = _productService.GetProductsWithPaging(page, pagesize, includeNavigation);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products));

        }
        [HttpGet("{productId}")]
        public ActionResult<ProductForPostRequestDto> GetProduct(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<Product, ProductForPostRequestDto>(product));
        }

        [HttpPost("createproduct")]
        public ActionResult<ProductForPostRequestDto> CreateProduct(ProductForPostRequestDto product)
        {
            var productDomain = _mapper.Map<ProductForPostRequestDto, Product>(product);
            var returnProduct = _productService.AddProduct(productDomain);

            return Ok(_mapper.Map<Product, ProductForPostRequestDto>(returnProduct));
        }

        [HttpPut("updateproduct")]
        public ActionResult<ProductForPostRequestDto> UpdateProduct(int productId, ProductForPostRequestDto product)
        {
            if (productId == 0)
            {
                return BadRequest();
            }
            if (productId != product.ProductId)
            {   
                return BadRequest();
            }
            var productToUpdate = _productService.GetProductById(productId);
            if (productToUpdate == null) return BadRequest();

            var productDomain = _mapper.Map<ProductForPostRequestDto, Product>(product);

            _productService.UpdateProduct(productToUpdate, productDomain);

            return Ok(product);
        }
        [HttpDelete("deleteproduct")]
        public ActionResult DeleteProduct(int productId)
        {
            if (productId == 0)
            {
                return BadRequest();
            }

            var productToUpdate = _productService.GetProductById(productId);
            if (productToUpdate == null) return BadRequest();

            _productService.RemoveProduct(productToUpdate);

            return Ok();
        }
    }
}
