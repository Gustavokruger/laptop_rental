using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.RentItems;
using laptop_rental.Domain.Rents.Dtos;
using laptop_rental.laptop_rental.Domain.RentItems.Dtos;

namespace laptop_rental.Domain.Rents
{
    public class Rent : BaseEntity
    {

        [Required(ErrorMessage = "Obligatory Field")]
        public string RentDate { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentExpirationDate { get; set; }
        public string Status { get; set; }
        public decimal FullPrice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<RentItem> Items { get; set; }

        public Rent(RentInput rentInput)
        {
            Id = rentInput.Id;
            RentDate = rentInput.RentDate;
            rentExpirationDate = rentInput.rentExpirationDate;
            Status = rentInput.Status;
            FullPrice = rentInput.FullPrice;
            CustomerId = rentInput.CustomerId;
            Customer = rentInput.Customer;
            Items = new List<RentItem>(rentInput.Items);
        }

        public Rent()
        {

        }
    }
}