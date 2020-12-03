using System;
using System.Collections.Generic;
using laptop_rental.Domain.Models;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Base;

namespace laptop_rental.Domain.Models
{
    public class Customer : BaseModel
    {

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
        public virtual ICollection<Rent> rent { get; set; }
    }
}