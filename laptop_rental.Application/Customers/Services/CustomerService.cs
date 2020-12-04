using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Application.Customers.Services.Interfaces;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Domain.Customers.Services;
using laptop_rental.Infraestructure.Customers;
using Microsoft.AspNetCore.Mvc;
namespace laptop_rental.Application.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerLoginService _customerLoginService;

        public CustomerService(ICustomerRepository customerRepository, ICustomerLoginService customerLoginService)
        {
            _customerRepository = customerRepository;
            _customerLoginService = customerLoginService;

        }
        public async Task<string> login(CustomerLogin customerLogin)
        {
            return await _customerLoginService.login(customerLogin);
        }
        public ActionResult<List<CustomerOutput>> list()
        {
            return _customerRepository
            .list()
            .Select(customer => new CustomerOutput(customer))
            .ToList();
        }

        public async Task<ActionResult<CustomerOutput>> findByIdAsync(int id)
        {
            var customer = await _customerRepository.findByIdAsync(id);
            if (customer != null)
            {
                return new CustomerOutput(customer);
            }
            return null;
        }

        public async Task addAsync(CustomerInput customer)
        {
            await _customerRepository.addAsync(new Customer(customer));
        }

        public async Task update(CustomerInput customer)
        {
            await _customerRepository.update(new Customer(customer));
        }
        public async Task remove(int id)
        {
            await _customerRepository.remove(id);
        }
    }
}