using System.Collections.Generic;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.RentItems;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;

namespace laptop_rental.Dtos
{
    public class SimulateRent
    {
        public Customer customer { get; set; }
        public int customerId { get; set; }
        public virtual ICollection<RentItemInput> items { get; set; }
        public string rentDate { get; set; }
        public string rentExpirationDate { get; set; }
        public decimal fullPrice { get; set; }
    }
}