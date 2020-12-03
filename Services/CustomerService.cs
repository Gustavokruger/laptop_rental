using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }
        public async Task<ActionResult<IEnumerable<Customer>>> listAsync()
        {
            return await _customerRepository.listAsync();
        }

        public async Task<ActionResult<Customer>> findByIdAsync(int id)
        {
            return await _customerRepository.findByIdAsync(id);
        }

        public async Task addAsync(Customer customer)
        {
            await _customerRepository.addAsync(customer);
        }

        public async Task update(Customer customer)
        {
            await _customerRepository.update(customer);
        }
        public async Task remove(int id)
        {
            await _customerRepository.remove(id);

        }


    }
}