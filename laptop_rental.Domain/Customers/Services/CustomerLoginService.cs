using System.Threading.Tasks;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Dtos;
using laptop_rental.Infraestructure.Customers;
using laptop_rental.Persistence.Repositories;


namespace laptop_rental.Domain.Customers.Services
{
    public class CustomerLoginService : ICustomerLoginService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IGenerateTokenService _tokenService;

        public CustomerLoginService(ICustomerRepository customer, IGenerateTokenService tokenService)
        {
            _customerRepository = customer;
            _tokenService = tokenService;
        }
        public async Task<string> login(CustomerLogin customerLogin)
        {
            var customer = await _customerRepository.login(customerLogin);

            if (customer != null)
            {
                var token = _tokenService.generateToken(customer);

                return token;
            }

            return null;
        }
    }
}