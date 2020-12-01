using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using laptop_rental.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }
        public async Task<ActionResult<IEnumerable<Order>>> listAsync()
        {
            return await _orderRepository.listAsync();
        }

        public async Task<ActionResult<Order>> findByIdAsync(int id)
        {
            return await _orderRepository.findByIdAsync(id);
        }

        public async Task addAsync(Order order)
        {
            await _orderRepository.addAsync(order);
        }

        public void update(Order order)
        {
            _orderRepository.update(order);
        }
        public void remove(Order order)
        {
            _orderRepository.remove(order);

        }
    }
}