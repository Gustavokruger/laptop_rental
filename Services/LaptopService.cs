
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;

        public LaptopService(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;

        }
        public async Task<ActionResult<IEnumerable<Laptop>>> listAsync()
        {
            return await _laptopRepository.listAsync();
        }

        public async Task<ActionResult<Laptop>> findByIdAsync(int id)
        {
            return await _laptopRepository.findByIdAsync(id);
        }

        public async Task addAsync(Laptop laptop)
        {
            await _laptopRepository.addAsync(laptop);
        }

        public async Task update(Laptop laptop)
        {
            await _laptopRepository.update(laptop);
        }
        public void remove(Laptop laptop)
        {
            _laptopRepository.remove(laptop);

        }

    }
}