using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CustomerService");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Customer 1", Email = "Customer1@example.com", Phone = "555-982-3467" },
                new Customer { Id = 2, Name = "Customer 2", Email = "Customer2@example.com", Phone = "732-867-9210" },
                new Customer { Id = 3, Name = "Customer 3", Email = "Customer3@example.com", Phone = "415-621-3984" }
            );
        }
    }
}
