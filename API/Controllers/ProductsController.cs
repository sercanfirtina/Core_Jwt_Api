using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using API.CustomFilters;
using AutoMapper;
using Business.Interfaces;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
            //businesstaki product servise gidecek sonra product managerın örneğini alırken generic managerı görecek
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
           // await _productService.Add(new Product { Name = productAddDto.Name });
            await _productService.Add(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.Update(_mapper.Map<Product>(productUpdateDto));
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Remove(new Product() { Id = id });
            return NoContent();
        }

        [Route("/error")]
        public IActionResult Error()
        {
           var errorInfo= HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //loglama
            return Problem(detail: "An error occured in api");
        }


    }
}
