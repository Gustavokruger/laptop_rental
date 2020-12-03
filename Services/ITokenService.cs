using laptop_rental.Domain.Models;

namespace laptop_rental.Services
{
    public interface ITokenService
    {
        public string generateToken(Customer customer);
    }
}