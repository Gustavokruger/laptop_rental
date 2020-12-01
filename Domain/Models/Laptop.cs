using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace laptop_rental.Domain.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string brand { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string model { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal dailyPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal dailyLateFee { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}