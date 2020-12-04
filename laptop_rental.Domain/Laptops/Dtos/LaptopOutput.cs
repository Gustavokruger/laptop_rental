using System.Collections.Generic;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Laptops.Dtos
{
    public class LaptopOutput : ILaptop
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Details { get; set; }
        public int StockAmount { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal DailyLateFee { get; set; }
        public virtual ICollection<IRentItem> items { get; set; }

        public LaptopOutput(Laptop laptop)
        {
            Brand = laptop.Brand;
            Model = laptop.Model;
            Details = laptop.Details;
            StockAmount = laptop.StockAmount;
            DailyPrice = laptop.DailyPrice;
            DailyLateFee = laptop.DailyLateFee;
            items = laptop.items;
        }
    }
}