using System.Collections.Generic;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Dtos
{
    public class SimulateRent
    {
        public Customer customer { get; set; }
        public virtual ICollection<RentItem> items { get; set; }
        public string rentDate { get; set; }
        public string rentExpirationDate { get; set; }
        public decimal fullPrice { get; set; }
    }
}