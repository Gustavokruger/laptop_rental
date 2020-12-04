using System;
using System.Collections.Generic;
using laptop_rental.Domain.Rents;

namespace laptop_rental.Domain.Customers
{
    public interface ICustomer
    {
        string Email { get; set; }
        string Password { get; set; }
        string FullName { get; set; }
        Boolean IsLegal { get; set; }
        string Cpf { get; set; }
        string Cnpj { get; set; }
        ICollection<IRent> Rents { get; set; }
    }
}