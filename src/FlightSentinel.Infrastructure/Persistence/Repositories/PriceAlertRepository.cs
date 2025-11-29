using FlightSentinel.Domain.Entities;
using FlightSentinel.Domain.Enums;
using FlightSentinel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSentinel.Infrastructure.Persistence.Repositories
{
    public class PriceAlertRepository : IPriceAlertRepository
    {
        private readonly AppDbContext _context;

        public PriceAlertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PriceAlert> CreateAsync(PriceAlert alert)
        {
            await _context.PriceAlerts.AddAsync(alert);
            return alert;
        }

        public async Task DeleteAsync(Guid alertId)
        {
            var item = await _context.PriceAlerts.FindAsync(alertId);   
            if (item != null)
                _context.PriceAlerts.Remove(item);  
        }

        public async Task<IEnumerable<PriceAlert>> GetActiveAlertsAsync()
        {
            return await _context.PriceAlerts
                .Where(x => x.Status == AlertStatus.Active)
                .ToListAsync();
        }

        public async Task<PriceAlert> GetByIdAsync(Guid alertId)
        {
            return await _context.PriceAlerts
                .Include(x => x.User)
                .Include(x => x.History)
                .FirstOrDefaultAsync(x => x.AlertId == alertId);
        }

        public async Task<IEnumerable<PriceAlert>> GetByUserAsync(Guid userId)
        {
            return await _context.PriceAlerts
                .Where(x => x.UserId == userId)
                .ToListAsync(); 
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PriceAlert alert)
        {
            _context.PriceAlerts.Update(alert);
        }
    }
}
