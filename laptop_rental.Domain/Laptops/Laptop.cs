using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.RentItems;

namespace laptop_rental.Domain.Laptops
{
    public class Laptop : BaseEntity, ILaptop
    {

        [Required(ErrorMessage = "Obligatory Field")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public int StockAmount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal DailyPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal DailyLateFee { get; set; }

        public virtual ICollection<IRentItem> items { get; set; }

        public Laptop(ILaptop laptop)
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