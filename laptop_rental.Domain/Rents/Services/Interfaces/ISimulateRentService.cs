using System.Threading.Tasks;
using laptop_rental.Dtos;

namespace laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces
{
    public interface ISimulateRentService
    {
        SimulateRent simulate(SimulateRent rent);
    }
}