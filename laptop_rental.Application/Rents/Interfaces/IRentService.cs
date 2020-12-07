using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Rents.Dtos;
using laptop_rental.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace laptop_rental.Application.Rents.Services.Interfaces
{
    public interface IRentService
    {
        ActionResult<List<RentOutput>> list();
        Task<ActionResult<RentOutput>> findByIdAsync(int id);
        Task<ActionResult<RentOutput>> create(RentInput rent);
        Task update(RentInput rent);
        Task remove(int id);
        Task<SimulateRent> simulate(SimulateRent rent);
        Task refund(int id);
    }
}