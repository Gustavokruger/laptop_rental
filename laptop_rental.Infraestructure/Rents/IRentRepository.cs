using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laptop_rental.Domain.Rents;
using Microsoft.AspNetCore.Mvc;

namespace laptop_rental.Infraestructure.Rents
{
    public interface IRentRepository
    {
        IQueryable<Rent> list();
        Task addAsync(Rent rent);
        Task<Rent> findByIdAsync(int id);
        Task update(Rent rent);
        Task remove(int id);
    }
}