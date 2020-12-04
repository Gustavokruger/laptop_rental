using System.Collections.Generic;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Laptops
{
    public interface ILaptop
    {
        string Brand { get; set; }
        string Model { get; set; }
        string Details { get; set; }
        int StockAmount { get; set; }
        decimal DailyPrice { get; set; }

        decimal DailyLateFee { get; set; }

        abstract ICollection<IRentItem> items { get; set; }

    }
}