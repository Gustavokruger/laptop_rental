using System.Threading.Tasks;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Dtos;

namespace laptop_rental.Domain.Customers.Services
{
    public interface ICustomerLoginService
    {
        Task<string> login(CustomerLogin customerLogin);
    }
}