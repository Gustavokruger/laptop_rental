using System;
using System.ComponentModel.DataAnnotations;

namespace laptop_rental.Dtos
{
    public class LaptopDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string brand { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string model { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal dailyPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 0")]
        public decimal dailyLateFee { get; set; }

        private class KeyAttribute : Attribute
        {
        }
    }
}