using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Rent>>> getAllAsync()
        {

            return await _rentService.listAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Rent>> getById(int id)
        {

            return await _rentService.findByIdAsync(id);

        }

        [HttpGet]
        [Route("simulate")]
        public Rent simulate([FromBody] Rent rent)
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

            }
            return rent;
        }

        [HttpPost]
        [Route("create")]
        public async Task create([FromBody] Rent rent)
        {
            if (ModelState.IsValid)
            {

                foreach (var item in rent.items)
                {
                    var laptop = (await _laptopService.findByIdAsync(item.laptopId)).Value;
                    laptop.stockAmount -= 1;
                    await _laptopService.update(laptop);
                }

                rent.status = "efetuado";

                await _rentService.addAsync(rent);
            }
        }

        [HttpPut]
        [Route("refund/{id:int}")]
        public async Task refund(int id)
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

                    _rentService.update(rent);
                }
            }

        }


    }
}