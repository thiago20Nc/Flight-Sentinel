using FlightSentinel.Domain.Entities;

namespace FlightSentinel.Domain.Interfaces
{
    public interface IPriceAlertRepository
    {
        Task<PriceAlert> CreateAsync(PriceAlert alert);
        Task<PriceAlert> GetByIdAsync(Guid alertId);
        Task<IEnumerable<PriceAlert>> GetByUserAsync(Guid userId);
        Task<IEnumerable<PriceAlert>> GetActiveAlertsAsync();

        Task UpdateAsync(PriceAlert alert);
        Task DeleteAsync(Guid alertId);

        Task SaveChangesAsync();
    }
}
