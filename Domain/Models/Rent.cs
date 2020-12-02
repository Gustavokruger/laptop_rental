using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class Rent : BaseModel
    {
        public int orderId { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public Order order { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentDate { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentExpirationDate { get; set; }
        public string status { get; set; }
        public decimal fullPrice { get; set; }
    }
}