using System.Threading.Tasks;
using laptop_rental.Domain.Rents.Dtos;

namespace laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces
{
    public interface ICreateRentService
    {
        Task create(RentInput rent);
    }
}