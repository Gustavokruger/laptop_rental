using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Laptop>>> findAllAsync()
        {
            return await _laptopService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Laptop>> findById(int id)
        {
            return await _laptopService.findByIdAsync(id);

        }

        [HttpGet]
        [Route("{brand:String}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Laptop>>> findByBrand(string brand)
        {
            return await _laptopService.findByBrand(brand);

        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task create([FromBody] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                await _laptopService.addAsync(laptop);
            }
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task update([FromBody] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                await _laptopService.update(laptop);
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _laptopService.remove(id);
            }
        }



    }
}