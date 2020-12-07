using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Application.Laptops.Services;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.RentItems;
using laptop_rental.Domain.Rents;
using laptop_rental.Domain.Rents.Dtos;
using laptop_rental.Infraestructure.Customers;
using laptop_rental.Infraestructure.Laptops;
using laptop_rental.Infraestructure.Rents;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;
using laptop_rental.laptop_rental.Domain.RentItems.Services;
using laptop_rental.laptop_rental.Domain.RentItems.Services.Interfaces;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.laptop_rental.Domain.Rents.Services
{
    public class CreateRentService : ICreateRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly ILaptopRepository _laptopRepository;
        private readonly IValidateItemStock _validateItemStock;
        private readonly ICustomerRepository _customerRepository;

        public CreateRentService(
            IRentRepository rentRepository,
            ILaptopRepository laptopRepository,
            IValidateItemStock validateItemStock,
            ICustomerRepository customerRepository)
        {
            _rentRepository = rentRepository;
            _laptopRepository = laptopRepository;
            _validateItemStock = validateItemStock;
            _customerRepository = customerRepository;

        }

        public async Task<ActionResult<RentOutput>> create(RentInput rent)
        {
            foreach (var item in rent.Items)
            {
                if (!(await _validateItemStock.validate(new RentItemInput(item))))
                {
                    return null;
                }
                item.laptop = (await _laptopRepository.findByIdAsync(item.laptopId)).Value;
            }
            rent.Status = "efetuado";
            await _rentRepository.addAsync(new Rent(rent));
            rent.Customer = await _customerRepository.findByIdAsync(rent.CustomerId);
            return new RentOutput(new Rent(rent));
        }
    }
}