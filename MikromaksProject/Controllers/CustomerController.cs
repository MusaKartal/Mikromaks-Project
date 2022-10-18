using BusinessLayer.Abstract;
using EntitiesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MikromaksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] Customer customer)
        {
            var customerEmail = _customerService.FirstOrDefault(customer);
            if (customerEmail == null)
            {
                return NotFound();
            }
            var customerJwt = _customerService.Login(customer);
            return Ok(customerJwt);
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] Customer customer)
        {
            var customerEmail = _customerService.FirstOrDefault(customer);
            if (customerEmail != null)
            {
                return BadRequest("User with same already exists");
            }
            _customerService.Register(customer);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
