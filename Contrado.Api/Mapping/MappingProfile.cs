using AutoMapper;
using Contrado.Api.Dtos;
using Contrado.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contrado.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Product, ProductForPostRequestDto>().ForMember(
                dto => dto.ProductAttributesDto,
                                    opt => opt.MapFrom(x => x.ProductAttributes.Select(y => new ProductAttributesDTO
                                    {
                                        AttributeId = y.AttributeId,
                                        AttributeValue = y.AttributeValue,
                                        ProductId = y.ProductId,
                                        AttributeName = y.AttributeLookup.AttributeName
                                    }).ToList()));

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductAttributeLookup, ProductAttributesDTO>();
            CreateMap<Product, ProductDto>();

            // DTO to Domain
            CreateMap<ProductForPostRequestDto, Product>().AfterMap((s, d) =>
                     {
                         var attributes = new List<ProductAttribute>();
                         var lookups = new List<ProductAttributeLookup>();

                         foreach (var item in s.ProductAttributesDto)
                         {
                             var attribute = new ProductAttribute
                             {
                                 AttributeId = item.AttributeId,
                                 AttributeValue = item.AttributeValue,
                                 ProductId = item.ProductId,
                                 Product = new Product
                                 {
                                     ProdCatId = s.ProdCatId,
                                     ProdDescription = s.ProdDescription,
                                     ProdName = s.ProdName,
                                     ProductId = s.ProductId
                                 }
                             };
                             var lookup = new ProductAttributeLookup
                             {

                                 AttributeId = item.AttributeId,
                                 AttributeName = item.AttributeName,
                                 ProdCatId = s.ProdCatId
                             };
                             attribute.AttributeLookup = lookup;
                             attributes.Add(attribute);

                         }
                         //  d.ProductCategory = new ProductCategory { CategoryName = s.ProductCategory.CategoryName, ProdCatId = s.ProductCategory.ProdCatId };
                         d.ProductAttributes = attributes;

                     });
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductDto, Product>();
            CreateMap<ProductAttributesDTO, ProductAttributeLookup>()
            .ForMember(mem => mem.ProductAttributes,
            source => source.MapFrom(x => new ProductAttribute
            {
                AttributeId = x.AttributeId,
                AttributeValue = x.AttributeValue,
                AttributeLookup = new ProductAttributeLookup { AttributeName = x.AttributeName, AttributeId = x.AttributeId }
            }));

        }
    }
}

