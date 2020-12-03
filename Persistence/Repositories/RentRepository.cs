
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptoprental.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace laptop_rental.Persistence.Repositories
{
    public class RentRepository : BaseRepository, IRentRepository
    {
        public RentRepository(DataContext context) : base(context)
        {

        }
        public async Task<ActionResult<IEnumerable<Rent>>> listAsync()
        {
            return await Task.FromResult(_context.Rents
            .Include(rent => rent.customer)
            .Include(rent => rent.items)
            .ThenInclude(item => item.laptop)
            .ToList());
        }
        public async Task addAsync(Rent rent)
        {

            await _context.Rents.AddAsync(rent);
            await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<Rent>> findByIdAsync(int id)
        {
            return await _context.Rents
            .Include(rent => rent.customer)
            .Include(rent => rent.items)
            .FirstOrDefaultAsync(rent => rent.Id == id);
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