using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace laptop_rental.Services
{
    public interface IRentService
    {
        Task<ActionResult<IEnumerable<Rent>>> listAsync();
        Task<ActionResult<Rent>> findByIdAsync(int id);
        Task addAsync(Rent rent);
        void update(Rent rent);
        void remove(Rent rent);
    }
}