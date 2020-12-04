using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Customers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Infraestructure.Customers
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> list();
        Task addAsync(Customer customer);
        Task<Customer> findByIdAsync(int id);
        Task update(Customer customer);
        Task remove(int id);
        Task<Customer> login(CustomerLogin customerLogin);
    }
}