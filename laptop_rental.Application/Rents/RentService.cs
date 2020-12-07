using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Application.Rents.Services.Interfaces;
using laptop_rental.Domain.Rents;
using laptop_rental.Domain.Rents.Dtos;
using laptop_rental.Dtos;
using laptop_rental.Infraestructure.Rents;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Application.Rents.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly ISimulateRentService _simulateRentService;
        private readonly ICreateRentService _createRentService;
        private readonly IRefundRentService _refundRentService;
        public RentService(
        IRentRepository rentRepository,
        ISimulateRentService simulateRentService,
        ICreateRentService createRentService,
        IRefundRentService refundRentService)
        {
            _rentRepository = rentRepository;
            _simulateRentService = simulateRentService;
            _createRentService = createRentService;
            _refundRentService = refundRentService;

        }
        public ActionResult<List<RentOutput>> list()
        {
            return _rentRepository
            .list()
            .Select(rent => new RentOutput(rent))
            .ToList();
        }

        public async Task<ActionResult<RentOutput>> findByIdAsync(int id)
        {
            var laptop = await _rentRepository.findByIdAsync(id);
            if (laptop != null)
            {
                return new RentOutput(laptop);
            }
            return null;
        }

        public async Task<ActionResult<RentOutput>> create(RentInput rent)
        {
            return await _createRentService.create(rent);
        }

        public async Task update(RentInput rent)
        {
            await _rentRepository.update(new Rent(rent));
        }
        public async Task remove(int id)
        {
            await _rentRepository.remove(id);

        }
        public async Task<SimulateRent> simulate(SimulateRent rent)
        {
            return await _simulateRentService.simulate(rent);
        }

        public async Task refund(int id)
        {
            await _refundRentService.refund(id);
        }
    }
}