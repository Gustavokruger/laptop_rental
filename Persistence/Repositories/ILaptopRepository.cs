using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Persistence.Repositories
{
    public interface ILaptopRepository
    {
        Task<ActionResult<IEnumerable<Laptop>>> listAsync();
        Task addAsync(Laptop laptop);
        Task<ActionResult<Laptop>> findByIdAsync(int id);
        Task<ActionResult<IEnumerable<Laptop>>> findByBrand(string brand);
        Task update(Laptop laptop);
        Task remove(int id);

    }
}