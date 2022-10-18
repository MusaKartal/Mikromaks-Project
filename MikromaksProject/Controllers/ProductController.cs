using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiesLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MikromaksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
       private readonly IProductService _productService;
       public ProductController(IProductService productService) 
       {
          _productService = productService;
        
       }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.Create(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productsGet = _productService.GetAll();
            return Ok(productsGet);
        }

    }
}
