using FlightSentinel.Domain.Entities;
using FlightSentinel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSentinel.Infrastructure.Persistence.Repositories
{
    public class PriceCheckHistoryRepository : IPriceCheckHistoryRepository
    {
        private readonly AppDbContext _context;
        public PriceCheckHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PriceCheckHistory> CreateAsync(PriceCheckHistory history)
        {
            await _context.PriceCheckHistories.AddAsync(history);
            return history;
        }

        public async Task<IEnumerable<PriceCheckHistory>> GetByAlertIdAsync(Guid alertId)
        {
            return await _context.PriceCheckHistories
                .Where(x => x.AlertId == alertId)
                .OrderByDescending(x => x.FoundAt)
                .ToListAsync();
        }

        public async Task<PriceCheckHistory> GetLastCheckAsync(Guid alertId)
        {
            return await _context.PriceCheckHistories
                .Where(x => x.AlertId == alertId)
                .OrderByDescending(x => x.FoundAt)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
