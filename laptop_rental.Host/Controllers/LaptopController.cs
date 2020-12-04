

using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Application.Laptops.Services.Interfaces;
using laptop_rental.Domain.Laptops.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<LaptopOutput>> findAllAsync()
        {
            return _laptopService.list();
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<LaptopOutput>> findById(int id)
        {
            return await _laptopService.findByIdAsync(id);

        }

        [HttpGet]
        [Route("{brand}")]
        [Authorize]
        public ActionResult<List<LaptopOutput>> findByBrand(string brand)
        {
            return _laptopService.findByBrand(brand);

        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task create([FromBody] LaptopInput laptop)
        {
            if (ModelState.IsValid)
            {
                await _laptopService.addAsync(laptop);
            }
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task update([FromBody] LaptopInput laptop)
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