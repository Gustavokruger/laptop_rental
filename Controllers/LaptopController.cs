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
    [Route("/laptops")]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        public LaptopController(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Laptop>>> getAllAsync()
        {
            // return await context.Laptops.Include(laptop => laptop.category).ToListAsync();
            return await _laptopService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Laptop>> getById(int id)
        {
            return await _laptopService.findByIdAsync(id);

        }

        [HttpPost]
        [Route("create")]
        public async Task create([FromBody] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                await _laptopService.addAsync(laptop);
            }
        }



    }
}