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
        private readonly IProductAttributeLookupService _attibuteLookupService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IProductAttributeLookupService attributeLookupService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;
            this._attibuteLookupService = attributeLookupService;

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
            Product product = _productService.GetProductById(productId);
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

        [HttpPut("updateproduct/{productId}")]
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

            var attributes = new List<ProductAttribute>();
            if (product.ProductAttributesDto.Count > 0)
            {
                productToUpdate.ProductAttributes.Clear();
                foreach (var item in product.ProductAttributesDto)
                {
                    var attribute = new ProductAttribute();

                    if (item.AttributeId > 0 && productToUpdate.ProductAttributes.Any(c => c.AttributeId == item.AttributeId))
                    {
                        var attr = productToUpdate.ProductAttributes.FirstOrDefault(c => c.AttributeId == item.AttributeId);
                        attr.AttributeLookup = new ProductAttributeLookup
                        {
                            
                            AttributeName = item.AttributeName,
                            ProdCatId = product.ProdCatId,
                        };
                        attr.AttributeId = item.AttributeId;
                        attr.AttributeValue = item.AttributeValue;
                        attr.ProductId = item.ProductId;
                        attr.Product = productToUpdate;
                    }
                    else
                    {
                        var attributeLookup = new ProductAttributeLookup
                        {

                            AttributeName = item.AttributeName,
                            ProdCatId = product.ProdCatId,

                        };
                        attribute.AttributeId = item.AttributeId;
                        attribute.AttributeLookup = attributeLookup;
                        attribute.AttributeValue = item.AttributeValue;
                        attribute.Product = productToUpdate;
                        attribute.ProductId = item.ProductId;
                        productToUpdate.ProductAttributes.Add(attribute);

                    }
                   
                }
            }
            _productService.UpdateProduct(productToUpdate);
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

        [HttpGet("productattributes/{categoryId}")]
        public ActionResult<IEnumerable<ProductAttributesDTO>> GetProductAttributesByCategoryId(int categoryId)
        {
            var attributesDomain = _attibuteLookupService.GetAll(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductAttributeLookup>, IEnumerable<ProductAttributesDTO>>(attributesDomain));
        }
    }
}
