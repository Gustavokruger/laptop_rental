using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class Rent : BaseModel
    {

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentDate { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string rentExpirationDate { get; set; }
        public string status { get; set; }
        public decimal fullPrice { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public virtual ICollection<RentItem> items { get; set; }
    }
}