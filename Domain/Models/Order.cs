using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class Order : BaseModel
    {
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public virtual ICollection<OrderItem> items { get; set; }

    }
}