using System;
using System.Collections.Generic;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.Customers.Dtos
{
    public class CustomerOutput : ICustomer
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Boolean IsLegal { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public virtual ICollection<IRent> Rents { get; set; }
        public CustomerOutput(ICustomer customer)
        {
            Email = customer.Email;
            Password = customer.Password;
            FullName = customer.FullName;
            IsLegal = customer.IsLegal;
            Cpf = customer.Cpf;
            Cnpj = customer.Cnpj;
            Rents = customer.Rents;

        }
    }
}