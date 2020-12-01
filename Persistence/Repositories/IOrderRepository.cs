using System.Collections.Generic;
using System.Threading.Tasks;
using laptop_rental.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Persistence.Repositories
{
    public interface IOrderRepository
    {
        Task<ActionResult<IEnumerable<Order>>> listAsync();
        Task addAsync(Order order);
        Task<ActionResult<Order>> findByIdAsync(int id);
        void update(Order order);
        void remove(Order order);
    }
}