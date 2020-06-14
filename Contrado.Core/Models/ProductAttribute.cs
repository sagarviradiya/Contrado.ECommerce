using System;
using System.Collections.Generic;

namespace Contrado.Core.Models
{
    public class ProductAttribute
    {
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        public virtual ProductAttributeLookup AttributeLookup { get; set; }
        public virtual Product Product { get; set; }
        public string AttributeValue { get; set; }
    }
}
