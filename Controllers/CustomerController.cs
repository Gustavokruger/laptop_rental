
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Services;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Controllers
{
    [ApiController]
    [Route("/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Customer>>> getAllAsync()
        {
            return await _customerService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> getById(int id)
        {
            return await _customerService.findByIdAsync(id);

        }

        [HttpPost]
        [Route("create")]
        public async Task create([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.addAsync(customer);
            }
        }
    }
}