using System.Threading.Tasks;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;

namespace laptop_rental.laptop_rental.Domain.RentItems.Services.Interfaces
{
    public interface IValidateItemStock
    {
        Task<bool> validate(RentItemInput item);
    }
}