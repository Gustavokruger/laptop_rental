
using laptop_rental.Domain.Rents;
using laptop_rental.Domain.Laptops;

namespace laptop_rental.Domain.RentItems
{
    public class RentItem : BaseEntity
    {
        public int quantity { get; set; }
        public int laptopId { get; set; }
        public Laptop laptop { get; set; }
        public int rentId { get; set; }
        public Rent rent { get; set; }
    }
}