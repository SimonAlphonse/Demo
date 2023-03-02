using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService
{
    public class CustomerManager
    {
        private readonly CustomerDbContext _context;

        public CustomerManager(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Customer> GetCustomerByCustomername(string name)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var Customer = await _context.Customers.FirstOrDefaultAsync(u => u.Id == id);
            _context.Customers.Remove(Customer!);
            await _context.SaveChangesAsync();
            return Customer!;
        }
    }
}