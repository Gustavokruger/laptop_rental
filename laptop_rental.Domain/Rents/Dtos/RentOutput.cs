using System.Collections.Generic;
using System.Linq;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Domain.RentItems;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;

namespace laptop_rental.Domain.Rents.Dtos
{
    public class RentOutput
    {
        public int Id { get; set; }
        public string RentDate { get; set; }
        public string rentExpirationDate { get; set; }
        public string Status { get; set; }
        public decimal FullPrice { get; set; }
        public int CustomerId { get; set; }
        public CustomerOutput Customer { get; set; }
        public virtual ICollection<RentItemOutput> Items { get; set; }

        public RentOutput(Rent rent)
        {
            Id = rent.Id;
            RentDate = rent.RentDate;
            rentExpirationDate = rent.rentExpirationDate;
            Status = rent.Status;
            FullPrice = rent.FullPrice;
            CustomerId = rent.CustomerId;
            Customer = new CustomerOutput(rent.Customer);
            Items = new List<RentItemOutput>(rent.Items.Select(item => new RentItemOutput(item)));
        }

        public RentOutput()
        {

        }
    }
}