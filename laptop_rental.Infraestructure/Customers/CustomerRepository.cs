
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Infraestructure.Contexts;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Infraestructure.Customers
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {

        public CustomerRepository(DataContext context) : base(context)
        {

        }

        public async Task<Customer> login(CustomerLogin customerLogin)
        {
            return await Task.FromResult(_context.Customers
            .Where(customer => customer.Email == customerLogin.email && customer.Password == customerLogin.password)
            .FirstOrDefault());
        }

        public IQueryable<Customer> list()
        {
            return _context.Customers;
        }

        public async Task addAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> findByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task remove(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

        }
    }
}