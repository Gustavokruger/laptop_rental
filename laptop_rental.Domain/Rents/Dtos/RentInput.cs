using System.Collections.Generic;
using laptop_rental.Domain.RentItems;
using laptop_rental.Domain.Customers;

namespace laptop_rental.Domain.Rents.Dtos
{
    public class RentInput : IRent
    {
        public string RentDate { get; set; }
        public string rentExpirationDate { get; set; }
        public string Status { get; set; }
        public decimal FullPrice { get; set; }
        public int CustomerId { get; set; }
        public ICustomer Customer { get; set; }
        public virtual ICollection<IRentItem> Items { get; set; }
    }
}