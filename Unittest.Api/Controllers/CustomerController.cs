using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unittest.Api.Models;
using Unittest.Api.Services;

namespace Unittest.Api.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO model)
        {
            return new OkObjectResult(await _customerService.CreateCustomer(model));
        }
    }
}