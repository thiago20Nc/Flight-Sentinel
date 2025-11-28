using FlightSentinel.Domain.Entities;

namespace FlightSentinel.Domain.Interfaces
{
    public interface IPriceCheckHistoryRepository
    {
        Task<PriceCheckHistory> CreateAsync(PriceCheckHistory history);
        Task<IEnumerable<PriceCheckHistory>> GetByAlertIdAsync(Guid alertId);
        Task<PriceCheckHistory> GetLastCheckAsync(Guid alertId);

        Task SaveChangesAsync();
    }
}
