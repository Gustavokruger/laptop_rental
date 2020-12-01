using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace laptop_rental.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;

        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;

        }
        public async Task<ActionResult<IEnumerable<Rent>>> listAsync()
        {
            return await _rentRepository.listAsync();
        }

        public async Task<ActionResult<Rent>> findByIdAsync(int id)
        {
            return await _rentRepository.findByIdAsync(id);
        }

        public async Task addAsync(Rent rent)
        {
            await _rentRepository.addAsync(rent);
        }

        public void update(Rent rent)
        {
            _rentRepository.update(rent);
        }
        public void remove(Rent rent)
        {
            _rentRepository.remove(rent);

        }
    }
}