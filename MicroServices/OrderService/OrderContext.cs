using OrderService.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderService
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrderService");
        }

        public DbSet<Order> Orders { get; set; }
    }
}