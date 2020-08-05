using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapping.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product,ProductAddDto>();

            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product,ProductUpdateDto>();


        }
    }
}
