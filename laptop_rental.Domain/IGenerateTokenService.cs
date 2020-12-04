using laptop_rental.Domain;
using laptop_rental.Domain.Customers;

namespace laptop_rental.Domain
{
    public interface IGenerateTokenService
    {
        public string generateToken(Customer customer);
    }
}