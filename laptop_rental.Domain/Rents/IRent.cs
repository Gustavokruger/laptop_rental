using System.Collections.Generic;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Rents
{
    public interface IRent
    {
        string RentDate { get; set; }
        string rentExpirationDate { get; set; }
        string Status { get; set; }
        decimal FullPrice { get; set; }
        int CustomerId { get; set; }
        ICustomer Customer { get; set; }
        ICollection<IRentItem> Items { get; set; }
    }
}