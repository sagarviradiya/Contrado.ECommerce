using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contrado.Api.Dtos
{
    public class ProductAttributesDTO
    {
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
