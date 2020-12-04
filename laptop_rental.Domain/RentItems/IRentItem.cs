using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.RentItems
{
    public interface IRentItem
    {
        int quantity { get; set; }
        int laptopId { get; set; }
        ILaptop laptop { get; set; }
        int rentId { get; set; }
        IRent rent { get; set; }
    }
}