using UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace UserService
{
    public class UserManager
    {
        private readonly UserDbContext _context;

        public UserManager(UserDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id) ?? new();
        }

        public async Task<User> GetUserByUsername(string name)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Name == name) ?? new();
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return new();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}