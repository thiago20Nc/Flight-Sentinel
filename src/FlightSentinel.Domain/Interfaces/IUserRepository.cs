using FlightSentinel.Domain.Entities;

namespace FlightSentinel.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByIdAsync(Guid userId);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();

        Task UpdateAsync(User user);
        Task DeleteAsync(Guid userId);

        Task SaveChangesAsync();
    }
}
