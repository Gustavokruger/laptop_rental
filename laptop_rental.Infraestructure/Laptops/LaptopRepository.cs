using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Laptops.Dtos;
using laptop_rental.Infraestructure.Contexts;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace laptop_rental.Infraestructure.Laptops
{
    public class LaptopRepository : BaseRepository, ILaptopRepository
    {
        public LaptopRepository(DataContext context) : base(context)
        {

        }
        public IQueryable<Laptop> list()
        {
            return _context.Laptops;
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

        public IQueryable<Laptop> findByBrand(string brand)
        {
            return _context.Laptops
            .Where(laptop => laptop.Brand.ToLower() == brand.ToLower());
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