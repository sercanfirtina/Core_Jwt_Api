using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.ProductDto
{
    public class ProductUpdateDto:Entities.Interfaces.IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
