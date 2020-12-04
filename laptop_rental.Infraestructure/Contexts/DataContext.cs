
using laptop_rental.Domain.Customers;
using laptop_rental.Domain.Laptops;
using laptop_rental.Domain.RentItems;
using laptop_rental.Domain.Rents;
using Microsoft.EntityFrameworkCore;

namespace laptop_rental.Infraestructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentItem> RentItems { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}