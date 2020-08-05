using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:GenericManager<Product>,IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IGenericDal<Product>genericDal, IProductDal productDal) :base(genericDal)
        {
            _productDal = productDal;
        }
    }
}
