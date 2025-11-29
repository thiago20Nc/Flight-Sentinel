using FlightSentinel.Domain.ValueObjects;

namespace FlightSentinel.Domain.Interfaces
{
    public interface IFlightPriceProvider
    {
        Task<decimal> GetLowestPriceAsync(AirportCode origin, AirportCode destination, DateTime startDate, DateTime endDate);
    }
}
