using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return await _context.Customers.ToListAsync();
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
        public async void update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async void remove(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

        }
    }
}