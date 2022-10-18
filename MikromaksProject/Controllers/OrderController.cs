using BusinessLayer.Abstract;
using EntitiesLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MikromaksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ordersGet = _orderService.GetAll();
            return Ok(ordersGet);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            var productId = _orderService.FirstOrDefault(order);
            if (productId == null)
            {
                return NotFound();
            }
            
            _orderService.Create(order);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok();
        }

    }
}
