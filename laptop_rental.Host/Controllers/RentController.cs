

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using laptop_rental.Application.Laptops.Services.Interfaces;
using laptop_rental.Application.Rents.Services.Interfaces;
using laptop_rental.Domain.Rents;
using laptop_rental.Domain.Rents.Dtos;
using laptop_rental.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Controllers
{
    [ApiController]
    [Route("/rents")]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;
        private readonly ILaptopService _laptopService;
        public RentController(IRentService rentService, ILaptopService laptopService)
        {
            _rentService = rentService;
            _laptopService = laptopService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<RentOutput>> list()
        {

            return _rentService.list();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<RentOutput>> findById(int id)
        {

            return await _rentService.findByIdAsync(id);

        }

        [HttpGet]
        [Route("simulate")]
        [Authorize]
        public ActionResult<SimulateRent> simulate([FromBody] SimulateRent rent)
        {
            if (ModelState.IsValid)
            {
                return _rentService.simulate(rent);
            }
            return this.StatusCode(500);
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<ActionResult> create([FromBody] RentInput rent)
        {
            if (ModelState.IsValid)
            {
                await _rentService.create(rent);

                return this.StatusCode(200);
            }
            return this.StatusCode(500);
        }

        [HttpPut]
        [Route("refund/{id:int}")]
        public async Task<ActionResult> refund(int id)
        {
            if (ModelState.IsValid)
            {
                await _rentService.refund(id);

                return this.StatusCode(200);
            }
            return this.StatusCode(500);

        }

        [HttpPut]
        [Route("update")]
        public async Task update([FromBody] RentInput rent)
        {
            if (ModelState.IsValid)
            {
                await _rentService.update(rent);
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _rentService.remove(id);
            }
        }


    }
}