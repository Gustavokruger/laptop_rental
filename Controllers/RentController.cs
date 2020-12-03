

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using laptop_rental.Domain.Models;
using laptop_rental.Dtos;
using laptop_rental.Services;
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
        public async Task<ActionResult<IEnumerable<Rent>>> findAllAsync()
        {

            return await _rentService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Rent>> findById(int id)
        {

            return await _rentService.findByIdAsync(id);

        }

        [HttpGet]
        [Route("simulate")]
        [Authorize]
        public ActionResult<RentSimulationDto> simulate([FromBody] RentSimulationDto rent)
        {
            if (ModelState.IsValid)
            {
                int daysAmount = (
                    DateTime
                    .ParseExact(
                        rent.rentExpirationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces)
                    .Subtract(
                        DateTime
                        .ParseExact(
                            rent.rentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces))).Days;

                rent.items
                .ToList()
                .ForEach(item =>
                {
                    rent.fullPrice += (item.laptop.dailyPrice * item.quantity * daysAmount);
                });


                return rent;

            }
            return this.StatusCode(500);
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<ActionResult> create([FromBody] Rent rent)
        {
            if (ModelState.IsValid)
            {

                foreach (var item in rent.items)
                {
                    var laptop = (await _laptopService.findByIdAsync(item.laptopId)).Value;
                    if (laptop.stockAmount >= item.quantity)
                    {
                        laptop.stockAmount -= 1;
                        await _laptopService.update(laptop);
                    }
                    else
                    {
                        return this.StatusCode(500);
                    }

                }
                rent.status = "efetuado";
                await _rentService.addAsync(rent);

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
                var rent = (await _rentService.findByIdAsync(id)).Value;
                if (rent.status != "devolvido")
                {
                    foreach (var item in rent.items)
                    {
                        var laptop = (await _laptopService.findByIdAsync(item.laptopId)).Value;
                        laptop.stockAmount += 1;
                        await _laptopService.update(laptop);
                    }

                    rent.status = "devolvido";

                    await _rentService.update(rent);

                }
                return this.StatusCode(200);
            }
            return this.StatusCode(500);

        }

        [HttpPut]
        [Route("update")]
        public async Task update([FromBody] Rent rent)
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