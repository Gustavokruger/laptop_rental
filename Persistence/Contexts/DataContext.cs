
using laptop_rental.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace laptoprental.Persistence.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}