using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace laptop_rental.Controllers
{
    [ApiController]
    [Route("/orders")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Order>>> getAllAsync()
        {

            return await _orderService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> getById(int id)
        {
            return await _orderService.findByIdAsync(id);

        }


        [HttpPost]
        [Route("create")]
        public async Task create([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.addAsync(order);
            }
        }




    }
}