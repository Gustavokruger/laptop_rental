
using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace laptop_rental.Services
{
    public interface IOrderService
    {
        Task<ActionResult<IEnumerable<Order>>> listAsync();
        Task<ActionResult<Order>> findByIdAsync(int id);
        Task addAsync(Order order);
        void update(Order order);
        void remove(Order order);
    }
}