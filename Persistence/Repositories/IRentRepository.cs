using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Persistence.Repositories
{
    public interface IRentRepository
    {
        Task<ActionResult<IEnumerable<Rent>>> listAsync();
        Task addAsync(Rent rent);
        Task<ActionResult<Rent>> findByIdAsync(int id);
        Task update(Rent rent);
        Task remove(int id);
    }
}