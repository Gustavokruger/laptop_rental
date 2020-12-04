using System.Collections.Generic;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Rents.Dtos
{
    public class RentOutput : IRent
    {
        public string RentDate { get; set; }
        public string rentExpirationDate { get; set; }
        public string Status { get; set; }
        public decimal FullPrice { get; set; }
        public int CustomerId { get; set; }
        public ICustomer Customer { get; set; }
        public virtual ICollection<IRentItem> Items { get; set; }

        public RentOutput(IRent rent)
        {
            RentDate = rent.RentDate;
            rentExpirationDate = rent.rentExpirationDate;
            Status = rent.Status;
            FullPrice = rent.FullPrice;
            Customer = rent.Customer;
            Items = rent.Items;
        }
    }
}