using System.Threading.Tasks;
using laptop_rental.Infraestructure.Laptops;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;
using laptop_rental.laptop_rental.Domain.RentItems.Services.Interfaces;

namespace laptop_rental.laptop_rental.Domain.RentItems.Services
{
    public class ValidateItemStock : IValidateItemStock
    {
        private readonly ILaptopRepository _laptopRepository;
        public ValidateItemStock(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public async Task<bool> validate(RentItemInput item)
        {
            var laptop = (await _laptopRepository.findByIdAsync(item.LaptopId)).Value;
            if (laptop.StockAmount > 0 && laptop.StockAmount >= item.Quantity)
            {
                laptop.StockAmount -= 1;
                await _laptopRepository.update(laptop);
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}