using laptop_rental.Domain.Laptops.Dtos;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.laptop_rental.Domain.RentItems.Dtos
{
    public class RentItemOutput
    {
        public int Quantity { get; set; }
        public int LaptopId { get; set; }
        public LaptopOutput Laptop { get; set; }

        public RentItemOutput(RentItem rentItem)
        {
            Quantity = rentItem.quantity;
            LaptopId = rentItem.laptopId;
            Laptop = new LaptopOutput(rentItem.laptop);
        }

        public RentItemOutput()
        {

        }
    }
}