
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Services
{
    public interface ICustomerService
    {
        Task<ActionResult<IEnumerable<Customer>>> listAsync();
        Task<ActionResult<Customer>> findByIdAsync(int id);
        Task addAsync(Customer customer);
        void update(Customer customer);
        void remove(Customer customer);
    }
}