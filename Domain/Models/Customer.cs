using System;
using System.Collections.Generic;
using laptop_rental.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace laptop_rental.Domain.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string email { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string password { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public Boolean isLegal { get; set; }

        public string cpf { get; set; }

        public string cnpj { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}