

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
        [Authorize]
        public ActionResult<List<RentOutput>> list()
        {

            return _rentService.list();
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<RentOutput>> findById(int id)
        {

            return await _rentService.findByIdAsync(id);

        }

        [HttpGet]
        [Route("simulate")]
        [Authorize]
        public async Task<ActionResult<SimulateRent>> simulate([FromBody] SimulateRent rent)
        {
            if (ModelState.IsValid)
            {
                if (await _rentService.simulate(rent) != null)
                {
                    return rent;
                }
                return this.StatusCode(500);

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
                if (await _rentService.create(rent) != null)
                {
                    return this.StatusCode(200);
                }
                return this.StatusCode(500);


            }
            return this.StatusCode(500);

        }

        [HttpPut]
        [Route("refund/{id:int}")]
        [Authorize]
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
        [Authorize]
        public async Task update([FromBody] RentInput rent)
        {
            if (ModelState.IsValid)
            {
                await _rentService.update(rent);
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _rentService.remove(id);
            }
        }


    }
}