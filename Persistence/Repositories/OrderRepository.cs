using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptoprental.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Persistence.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {

        }
        public async Task<ActionResult<IEnumerable<Order>>> listAsync()
        {
            return await Task.FromResult(_context.Orders
            .Include(order => order.customer)
            .ToList());
        }
        public async Task addAsync(Order order)
        {

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<Order>> findByIdAsync(int id)
        {
            return await _context.Orders
            .Include(order => order.customer)
            .FirstOrDefaultAsync(order => order.Id == id);
        }
        public async void update(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
        public async void remove(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

        }
    }
}