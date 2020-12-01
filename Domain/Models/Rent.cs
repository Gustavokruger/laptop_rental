using System.ComponentModel.DataAnnotations;

namespace laptop_rental.Domain.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public int orderId { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public Order order { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentDate { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentExpirationDate { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string status { get; set; }
    }
}