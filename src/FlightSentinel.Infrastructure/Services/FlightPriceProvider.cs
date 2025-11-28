using FlightSentinel.Domain.Interfaces;

namespace FlightSentinel.Infrastructure.Services
{
    public class FlightPriceProvider : IFlightPriceProvider
    {
        private readonly HttpClient _httpClient;    

        public FlightPriceProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<decimal> GetLowestPriceAsync(string origin, string destination, DateTime startDate, DateTime endDate)
        {
            // Aqui será colocada a chamada real da API externa
            // Por enquanto retorno uma simulação

            return await Task.FromResult(new Random().Next(400, 1500));
        }
    }
}
