using System.Threading.Tasks;
using laptop_rental.Infraestructure.Laptops;
using laptop_rental.Infraestructure.Rents;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;

namespace laptop_rental.laptop_rental.Domain.Rents.Services
{
    public class RefundRentService : IRefundRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly ILaptopRepository _laptopRepository;
        public RefundRentService(IRentRepository rentRepository, ILaptopRepository laptopRepository)
        {
            _rentRepository = rentRepository;
            _laptopRepository = laptopRepository;

        }

        public async Task refund(int id)
        {
            var rent = await _rentRepository.findByIdAsync(id);
            if (rent.Status != "devolvido")
            {
                foreach (var item in rent.Items)
                {
                    var laptop = (await _laptopRepository.findByIdAsync(item.laptopId)).Value;
                    laptop.StockAmount += 1;
                    await _laptopRepository.update(laptop);
                }

                rent.Status = "devolvido";

                await _rentRepository.update(rent);

            }
        }
    }
}