using System.ComponentModel.DataAnnotations;

namespace laptop_rental.Domain.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}