using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.RentItems
{
    public interface IRentItem
    {
        int quantity { get; set; }
        int laptopId { get; set; }
        Laptop laptop { get; set; }
        int rentId { get; set; }
        Rent rent { get; set; }
    }
}