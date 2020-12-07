using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Dtos;
using laptop_rental.Infraestructure.Customers;
using laptop_rental.Infraestructure.Laptops;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;
using laptop_rental.laptop_rental.Domain.RentItems.Services.Interfaces;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;

namespace laptop_rental.laptop_rental.Domain.Rents.Services
{
    public class SimulateRentService : ISimulateRentService
    {
        private readonly IValidateItemStock _validateItemStock;
        private readonly ILaptopRepository _laptopRepository;
        private readonly ICustomerRepository _customerRepository;
        public SimulateRentService(IValidateItemStock validateItemStock,
        ILaptopRepository laptopRepository,
        ICustomerRepository customerRepository)
        {
            _validateItemStock = validateItemStock;
            _laptopRepository = laptopRepository;
            _customerRepository = customerRepository;
        }
        public async Task<SimulateRent> simulate(SimulateRent rent)
        {
            foreach (var item in rent.items)
            {
                if (!(await _validateItemStock.validate(item)))
                {
                    return null;
                }
                item.Laptop = (await _laptopRepository.findByIdAsync(item.LaptopId)).Value;
            }
            int daysAmount = (
                    DateTime
                    .ParseExact(
                        rent.rentExpirationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces)
                    .Subtract(
                        DateTime
                        .ParseExact(
                            rent.rentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces))).Days;

            rent.customer = await _customerRepository.findByIdAsync(rent.customerId);
            rent.items
            .ToList()
            .ForEach(item =>
            {
                rent.fullPrice += (item.Laptop.DailyPrice * item.Quantity * daysAmount);
            });


            return rent;
        }
    }
}