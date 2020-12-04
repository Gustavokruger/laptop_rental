using System.Collections.Generic;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Laptops.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Application.Laptops.Services.Interfaces
{
    public interface IFindLaptopByBrandService
    {
        ActionResult<List<LaptopOutput>> findByBrand(string brand);
    }
}