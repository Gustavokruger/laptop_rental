using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Laptops.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Infraestructure.Laptops
{
    public interface ILaptopRepository
    {
        IQueryable<Laptop> list();
        Task addAsync(Laptop laptop);
        Task<ActionResult<Laptop>> findByIdAsync(int id);
        IQueryable<Laptop> findByBrand(string brand);
        Task update(Laptop laptop);
        Task remove(int id);

    }
}