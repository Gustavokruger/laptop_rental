using System.Collections.Generic;
using laptop_rental.Domain.Models;

namespace laptop_rental.Dtos
{
    public class RentSimulationDto
    {
        public Customer customer { get; set; }
        public virtual ICollection<RentItem> items { get; set; }
        public string rentDate { get; set; }
        public string rentExpirationDate { get; set; }
        public decimal fullPrice { get; set; }
    }
}