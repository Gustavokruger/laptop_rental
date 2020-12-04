using System;
using System.Collections.Generic;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.Customers.Dtos
{
    public class CustomerInput : ICustomer
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Boolean IsLegal { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public ICollection<IRent> Rents { get; set; }
    }
}