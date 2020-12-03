using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class RentItem : BaseModel
    {
        public int quantity { get; set; }
        public int laptopId { get; set; }
        public Laptop laptop { get; set; }

        public int rentId { get; set; }
        public Rent rent { get; set; }
    }
}