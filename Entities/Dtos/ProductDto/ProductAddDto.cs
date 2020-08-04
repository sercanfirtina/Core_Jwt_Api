using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Entities.Dtos.ProductDto
{
    public class ProductAddDto:IDto
    {
        public string Name { get; set; }
    }
}
