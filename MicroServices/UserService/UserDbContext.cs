using UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace UserService
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UserDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User 1", Email = "user1@example.com" },
                new User { Id = 2, Name = "User 2", Email = "user2@example.com" },
                new User { Id = 3, Name = "User 3", Email = "user3@example.com" }
            );
        }
    }
}
