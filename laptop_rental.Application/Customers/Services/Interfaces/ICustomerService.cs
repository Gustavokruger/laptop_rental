
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Customers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Application.Customers.Services.Interfaces
{
    public interface ICustomerService
    {
        ActionResult<List<CustomerOutput>> list();
        Task<ActionResult<CustomerOutput>> findByIdAsync(int id);
        Task addAsync(CustomerInput customer);
        Task update(CustomerInput customer);
        Task remove(int id);
        Task<string> login(CustomerLogin login);
    }
}