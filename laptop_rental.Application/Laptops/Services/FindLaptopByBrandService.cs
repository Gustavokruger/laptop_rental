using System.Collections.Generic;
using System.Linq;
using laptop_rental.Application.Laptops.Services.Interfaces;
using laptop_rental.Domain.Laptops.Dtos;
using laptop_rental.Infraestructure.Laptops;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Application.Laptops.Services
{
    public class FindLaptopByBrandService : IFindLaptopByBrandService
    {
        private readonly ILaptopRepository _laptopRepository;

        public FindLaptopByBrandService(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;

        }
        public ActionResult<List<LaptopOutput>> findByBrand(string brand)
        {
            return _laptopRepository
            .findByBrand(brand)
            .Select(laptop => new LaptopOutput(laptop))
            .ToList();
        }
    }
}