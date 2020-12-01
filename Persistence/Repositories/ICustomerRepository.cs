using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Persistence.Repositories
{
    public interface ICustomerRepository
    {
        Task<ActionResult<IEnumerable<Customer>>> listAsync();
        Task addAsync(Customer customer);
        Task<Customer> findByIdAsync(int id);
        void update(Customer customer);
        void remove(Customer customer);
    }
}