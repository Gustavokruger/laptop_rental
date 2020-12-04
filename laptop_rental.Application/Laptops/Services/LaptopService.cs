
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Application.Laptops.Services.Interfaces;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Laptops.Dtos;
using laptop_rental.Infraestructure.Laptops;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Application.Laptops.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IFindLaptopByBrandService _findLaptopByBrandService;

        public LaptopService(ILaptopRepository laptopRepository, IFindLaptopByBrandService findLaptopByBrandService)
        {
            _laptopRepository = laptopRepository;
            _findLaptopByBrandService = findLaptopByBrandService;

        }
        public ActionResult<List<LaptopOutput>> list()
        {
            return _laptopRepository.list()
            .Select(laptop => new LaptopOutput(laptop))
            .ToList();
        }

        public async Task<ActionResult<LaptopOutput>> findByIdAsync(int id)
        {
            var laptop = (await _laptopRepository.findByIdAsync(id)).Value;
            if (laptop != null)
            {
                return new LaptopOutput(laptop);
            }
            return null;
        }

        public ActionResult<List<LaptopOutput>> findByBrand(string brand)
        {
            return _findLaptopByBrandService.findByBrand(brand);
        }


        public async Task addAsync(LaptopInput laptop)
        {
            await _laptopRepository.addAsync(new Laptop(laptop));
        }

        public async Task update(LaptopInput laptop)
        {
            await _laptopRepository.update(new Laptop(laptop));
        }
        public async Task remove(int id)
        {
            await _laptopRepository.remove(id);

        }

    }
}