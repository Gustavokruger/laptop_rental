using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Rents
{
    public class Rent : BaseEntity, IRent
    {

        [Required(ErrorMessage = "Obligatory Field")]
        public string RentDate { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentExpirationDate { get; set; }
        public string Status { get; set; }
        public decimal FullPrice { get; set; }
        public int CustomerId { get; set; }
        public ICustomer Customer { get; set; }
        public virtual ICollection<IRentItem> Items { get; set; }

        public Rent(IRent rentInput)
        {
            RentDate = rentInput.RentDate;
            rentExpirationDate = rentInput.rentExpirationDate;
            Status = rentInput.Status;
            FullPrice = rentInput.FullPrice;
            Customer = rentInput.Customer;
            Items = rentInput.Items;
        }
    }
}