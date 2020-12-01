using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace laptop_rental.Domain.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obligatory Field")]
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public decimal price { get; set; }
        public virtual Rent rent { get; set; }
        public virtual ICollection<Laptop> Laptops { get; set; }

    }
}