using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
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
        public async Task<IActionResult>GetById(int id)
        {
            var product = await _productService.GetById(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult>Add(Product product)
        {
            await _productService.Add(product);
            return Created("", product);
        }

        [HttpPut]
        public async Task<IActionResult>Update(Product product)
        {
            await _productService.Update(product);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Remove(new Product() { Id = id });
            return NoContent();
        }

    }
}
