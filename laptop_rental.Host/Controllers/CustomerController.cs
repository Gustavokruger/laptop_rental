
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Application.Customers.Services.Interfaces;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Customers.Dtos;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Authenticate([FromBody] CustomerLogin customerLogin)
        {

            if (ModelState.IsValid)
            {
                var token = await _customerService.login(customerLogin);
                if (token != null)
                {
                    return token;
                }
                return NotFound(new { message = "Usuário ou senha inválidos" });

            }

            return this.StatusCode(500);
        }


        [HttpGet]
        [Route("")]
        [Authorize]
        public ActionResult<List<CustomerOutput>> findAllAsync()
        {
            return _customerService.list();
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<CustomerOutput>> findById(int id)
        {
            return await _customerService.findByIdAsync(id);

        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> create([FromBody] CustomerInput customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.addAsync(customer);
                return this.StatusCode(200);
            }
            return this.StatusCode(500);
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<ActionResult<dynamic>> update([FromBody] CustomerInput customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.update(customer);
                return this.StatusCode(200);
            }
            return this.StatusCode(500);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _customerService.remove(id);

            }
        }
    }
}