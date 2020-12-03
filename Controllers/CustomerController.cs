
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Dtos;
using laptop_rental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Controllers
{
    [ApiController]
    [Route("/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ITokenService _tokenService;
        public CustomerController(ICustomerService customerService, ITokenService tokenService)
        {
            _customerService = customerService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] CustomerLoginDto model)
        {

            if (ModelState.IsValid)
            {
                var customer = await _customerService.login(model);

                if (customer == null)
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }

                var token = _tokenService.generateToken(customer);

                customer.password = "";

                return new
                {
                    customer = customer,
                    token = token
                };
            }
            return this.StatusCode(500);
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Customer>>> getAllAsync()
        {
            return await _customerService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Customer>> getById(int id)
        {
            return await _customerService.findByIdAsync(id);

        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<ActionResult<dynamic>> create([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.addAsync(customer);
                return new
                {
                    customer = customer
                };
            }
            return this.StatusCode(500);
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<ActionResult<dynamic>> update([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.update(customer);
                return new
                {
                    customer = customer
                };
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