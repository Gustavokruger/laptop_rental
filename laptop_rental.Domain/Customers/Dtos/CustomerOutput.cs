using System;
using System.Collections.Generic;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.Customers.Dtos
{
    public class CustomerOutput
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public Boolean IsLegal { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public CustomerOutput(Customer customer)
        {
            Id = customer.Id;
            Email = customer.Email;
            FullName = customer.FullName;
            IsLegal = customer.IsLegal;
            Cpf = customer.Cpf;
            Cnpj = customer.Cnpj;

        }
        public CustomerOutput()
        {

        }
    }
}