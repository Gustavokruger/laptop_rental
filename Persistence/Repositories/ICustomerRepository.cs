using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Persistence.Repositories
{
    public interface ICustomerRepository
    {
        Task<ActionResult<IEnumerable<Customer>>> listAsync();
        Task addAsync(Customer customer);
        Task<Customer> findByIdAsync(int id);
        Task update(Customer customer);
        Task remove(int id);
        Task<Customer> login(CustomerLoginDto login);
    }
}