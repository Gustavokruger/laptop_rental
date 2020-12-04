using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using laptop_rental.Domain.Customers.Dtos;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.Customers
{
    public class Customer : BaseEntity
    {

        [Required(ErrorMessage = "Obligatory Field")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Obligatory Field")]
        public Boolean IsLegal { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public virtual ICollection<Rent> Rents { get; } = new List<Rent>();

        public Customer(CustomerInput customerInput)
        {
            Email = customerInput.Email;
            Password = customerInput.Password;
            FullName = customerInput.FullName;
            IsLegal = customerInput.IsLegal;
            Cpf = customerInput.Cpf;
            Cnpj = customerInput.Cnpj;

        }

        public Customer()
        {

        }
    }
}