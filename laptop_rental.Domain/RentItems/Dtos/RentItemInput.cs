using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.RentItems;
using laptop_rental.Domain.Rents;

namespace laptop_rental.laptop_rental.Domain.RentItems.Dtos
{
    public class RentItemInput
    {
        public int Quantity { get; set; }
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }
        public int RentId { get; set; }
        public Rent Rent { get; set; }

        public RentItemInput(RentItem rentItem)
        {
            Quantity = rentItem.quantity;
            LaptopId = rentItem.laptopId;
            Laptop = rentItem.laptop;
            RentId = rentItem.rentId;
            Rent = rentItem.rent;
        }

        public RentItemInput()
        {

        }
    }
}