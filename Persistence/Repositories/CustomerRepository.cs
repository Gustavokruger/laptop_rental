using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Persistence.Repositories;
using laptoprental.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace customer_rental.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {

        }
        public async Task<ActionResult<IEnumerable<Customer>>> listAsync()
        {
            return await Task.FromResult(_context.Customers.ToList());
        }
        public async Task addAsync(Customer customer)
        {
            Console.WriteLine(customer);
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