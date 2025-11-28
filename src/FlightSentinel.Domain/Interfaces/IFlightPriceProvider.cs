namespace FlightSentinel.Domain.Interfaces
{
    public interface IFlightPriceProvider
    {
        Task<decimal> GetLowestPriceAsync(string origin, string destination, DateTime startDate, DateTime endDate);
    }
}
