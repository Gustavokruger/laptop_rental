using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptoprental.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;


namespace laptop_rental.Persistence.Repositories
{
    public class LaptopRepository : BaseRepository, ILaptopRepository
    {
        public LaptopRepository(DataContext context) : base(context)
        {

        }
        public async Task<ActionResult<IEnumerable<Laptop>>> listAsync()
        {
            return await Task.FromResult(_context.Laptops.ToList());
        }
        public async Task addAsync(Laptop laptop)
        {

            await _context.Laptops.AddAsync(laptop);
            await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<Laptop>> findByIdAsync(int id)
        {
            return await _context.Laptops.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Laptop>>> findByBrand(string brand)
        {
            return await Task.FromResult(_context.Laptops
            .Where(laptop => laptop.brand.ToLower() == brand.ToLower())
            .ToList());
        }
        public async Task update(Laptop laptop)
        {
            _context.Update(laptop);
            await _context.SaveChangesAsync();
        }
        public async Task remove(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();

        }

    }
}