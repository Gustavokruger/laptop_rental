using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Application.Laptops.Services;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.RentItems;
using laptop_rental.Domain.Rents;
using laptop_rental.Domain.Rents.Dtos;
using laptop_rental.Infraestructure.Laptops;
using laptop_rental.Infraestructure.Rents;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.laptop_rental.Domain.Rents.Services
{
    public class CreateRentService : ICreateRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly ILaptopRepository _laptopRepository;

        public CreateRentService(IRentRepository rentRepository, ILaptopRepository laptopRepository)
        {
            _rentRepository = rentRepository;
            _laptopRepository = laptopRepository;

        }

        public async Task<ActionResult<RentOutput>> create(RentInput rent)
        {
            if (await validateStock(rent.Items.ToList()))
            {
                Console.WriteLine("sssssssssssssssss");
                rent.Status = "efetuado";
                await _rentRepository.addAsync(new Rent(rent));
                return new RentOutput(new Rent(rent));
            }

            return null;
        }



        public async Task<bool> validateStock(List<RentItem> rentItems)
        {

            foreach (var item in rentItems)
            {
                var laptop = (await _laptopRepository.findByIdAsync(item.laptopId)).Value;
                if (laptop.StockAmount >= item.quantity)
                {
                    laptop.StockAmount -= 1;
                    await _laptopRepository.update(laptop);
                }
                else
                {
                    return false;
                }

            }

            return true;

        }

    }
}