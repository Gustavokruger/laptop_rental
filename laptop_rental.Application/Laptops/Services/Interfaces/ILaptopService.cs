using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Laptops.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Application.Laptops.Services.Interfaces
{
    public interface ILaptopService
    {
        ActionResult<List<LaptopOutput>> list();
        Task<ActionResult<LaptopOutput>> findByIdAsync(int id);
        ActionResult<List<LaptopOutput>> findByBrand(string brand);
        Task addAsync(LaptopInput laptop);
        Task update(LaptopInput laptop);
        Task remove(int id);

    }
}