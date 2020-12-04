
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Rents;
using laptop_rental.Infraestructure.Contexts;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laptop_rental.Infraestructure.Rents
{
    public class RentRepository : BaseRepository, IRentRepository
    {
        public RentRepository(DataContext context) : base(context)
        {

        }
        public IQueryable<Rent> list()
        {
            return _context.Rents
            .Include(rent => rent.Customer)
            .Include(rent => rent.Items)
            .ThenInclude(item => item.laptop);
        }
        public async Task addAsync(Rent rent)
        {

            await _context.Rents.AddAsync(rent);
            await _context.SaveChangesAsync();
        }
        public async Task<Rent> findByIdAsync(int id)
        {
            return await _context.Rents
            .Include(rent => rent.Customer)
            .Include(rent => rent.Items)
            .Where(rent => rent.Id == id)
            .FirstOrDefaultAsync();
        }
        public async Task update(Rent rent)
        {
            _context.Update(rent);
            await _context.SaveChangesAsync();
        }
        public async Task remove(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

        }
    }
}