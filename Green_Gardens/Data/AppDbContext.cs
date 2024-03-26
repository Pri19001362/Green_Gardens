using Microsoft.EntityFrameworkCore;
using Green_Gardens.Model;

namespace Green_Gardens.Data
{
    public class AppDbContext : DbContext
    {
        //DbSet represents the collection of all entities in the context, or that can be queried from the databse, of a given type.
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        //Constructor for the AppDbContext class

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //The base constructor handles the options. {Connection strings and Database Provider)
        }
    }
}
