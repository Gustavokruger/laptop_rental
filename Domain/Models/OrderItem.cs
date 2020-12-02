using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class OrderItem : BaseModel
    {
        public int quantity { get; set; }
        public int laptopId { get; set; }
        public Laptop laptop { get; set; }
    }
}