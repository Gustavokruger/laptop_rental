using System.Threading.Tasks;

namespace laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces
{
    public interface IRefundRentService
    {
        Task refund(int id);
    }
}