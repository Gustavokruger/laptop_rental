using System.ComponentModel.DataAnnotations;

namespace laptop_rental.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}