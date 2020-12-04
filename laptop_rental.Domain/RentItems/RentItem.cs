
using laptop_rental.Domain.Rents;
using laptop_rental.Domain.Laptops;

namespace laptop_rental.Domain.RentItems
{
    public class RentItem : BaseEntity, IRentItem
    {
        public int quantity { get; set; }
        public int laptopId { get; set; }
        public ILaptop laptop { get; set; }
        public int rentId { get; set; }
        public IRent rent { get; set; }
    }
}