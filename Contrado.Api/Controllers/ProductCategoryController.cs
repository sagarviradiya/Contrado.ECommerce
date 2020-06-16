using System.Collections.Generic;
using AutoMapper;
using Contrado.Api.Dtos;
using Contrado.Core.Models;
using Contrado.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contrado.Api.Controllers
{
    [ApiController]
    [Route("api/productcategories")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;
        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductCategoryDto>> GetAllCategories()
        {
            var categoryDomains = this._productCategoryService.GetCategories();
            return Ok(this._mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDto>>(categoryDomains));
        }
    }
}