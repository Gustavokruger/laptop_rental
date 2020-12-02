using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class Laptop : BaseModel
    {

        [Required(ErrorMessage = "Obligatory Field")]
        public string brand { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string model { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string details { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public int stockAmount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal dailyPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal dailyLateFee { get; set; }

        public virtual ICollection<OrderItem> items { get; set; }


    }
}