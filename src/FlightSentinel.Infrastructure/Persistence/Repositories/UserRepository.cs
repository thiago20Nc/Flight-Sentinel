using FlightSentinel.Domain.Entities;
using FlightSentinel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSentinel.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        
        public UserRepository(AppDbContext context) 
        { 
            _context = context;
        }
        
        public async Task<User> CreateAsync(User user)
        {
            await _context.User.AddAsync(user);    
            return user;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var item = await _context.User.FindAsync(userId);
            if(item != null)
                _context.User.Remove(item);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.User
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _context.User
                .FirstOrDefaultAsync(x => x.UserId == userId);  
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.User.Update(user);
        }
    }
}
