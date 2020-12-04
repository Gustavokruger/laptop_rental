using System.Threading.Tasks;
using laptop_rental.Domain.Rents.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces
{
    public interface ICreateRentService
    {
        Task<ActionResult<RentOutput>> create(RentInput rent);
    }
}