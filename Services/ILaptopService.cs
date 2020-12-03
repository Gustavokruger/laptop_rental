using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Services
{
    public interface ILaptopService
    {
        Task<ActionResult<IEnumerable<Laptop>>> listAsync();
        Task<ActionResult<Laptop>> findByIdAsync(int id);
        Task<ActionResult<IEnumerable<Laptop>>> findByBrand(string brand);
        Task addAsync(Laptop laptop);
        Task update(Laptop laptop);
        Task remove(int id);

    }
}