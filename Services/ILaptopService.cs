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
        Task addAsync(Laptop laptop);
        Task update(Laptop laptop);
        void remove(Laptop laptop);

    }
}