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
            // Domain to DTO
            CreateMap<Product, ProductForPostRequestDto>()
                     .ForMember(dto => dto.ProductAttributesDto,
                      opt => opt.MapFrom(x => x.ProductAttributes.Select(y => new ProductAttributesDTO
                      {
                          AttributeId = y.AttributeId,
                          AttributeValue = y.AttributeValue,
                          ProductId = y.ProductId,
                          AttributeName = y.AttributeLookup.AttributeName
                      }).ToList()));


            // DTO to Domain
            CreateMap<ProductForPostRequestDto, Product>()
                .AfterMap((s, d) =>
                {
                    var attributes = new List<ProductAttribute>();
                    foreach (var item in s.ProductAttributesDto)
                    {
                        var attribute = new ProductAttribute
                        {
                            AttributeId = item.AttributeId,
                            AttributeValue = item.AttributeValue,
                            ProductId = item.ProductId
                        };
                        attributes.Add(attribute);
                    }
                    d.ProductAttributes = attributes;

                });
        }
    }
}
