using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            _productService.TInsert(product);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);   
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product) 
        {
            _productService.TUpdate(product);
            return Ok();
        }
        [HttpGet("ProductsWithCategory")]
        public IActionResult ProductsWithCategory()
        {
            var values = _productService.TGetProductsWithCategories();
            return Ok(values);
        }
    }
}
