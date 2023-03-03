using CustomerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManager _CustomerManager;

        public CustomerController(CustomerManager CustomerManager)
        {
            _CustomerManager = CustomerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _CustomerManager.GetCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(await _CustomerManager.GetCustomer(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer Customer)
        {
            var addedCustomer = await _CustomerManager.AddCustomer(Customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = addedCustomer.Id }, addedCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer Customer)
        {
            if (id != Customer.Id) return BadRequest();
            return Ok(await _CustomerManager.UpdateCustomer(Customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return Ok(await _CustomerManager.DeleteCustomer(id));
        }
    }
}