using System.Collections.Generic;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Laptops.Dtos
{
    public class LaptopInput
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Details { get; set; }
        public int StockAmount { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal DailyLateFee { get; set; }

    }
}