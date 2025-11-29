using FlightSentinel.Domain.Entities;
using FlightSentinel.Domain.Interfaces;

namespace FlightSentinel.Infrastructure.Jobs
{
    public class PriceCheckJob : IPriceCheckJob
    {
        private readonly IPriceAlertRepository _alerts;
        private readonly IPriceCheckHistoryRepository _history;
        private readonly IFlightPriceProvider _provider;
        private readonly IEmailSender _email;

        public PriceCheckJob(
            IPriceAlertRepository alerts,
            IPriceCheckHistoryRepository history,
            IFlightPriceProvider provider,
            IEmailSender email)
        {
            _alerts = alerts;
            _history = history;
            _provider = provider;
            _email = email;
        }

        public async Task ExecuteAsync()
        {
            var activeAlerts = await _alerts.GetActiveAlertsAsync();

            foreach (var alert in activeAlerts)
            {
                var price = await _provider.GetLowestPriceAsync(
                    alert.OriginAirport,
                    alert.DestinationAirport,
                    alert.OriginDate,
                    alert.ReturnDate
                );

                // registrar histórico
                var history = new PriceCheckHistory(
                    alert.AlertId,
                    price,
                    airline: "GRU" //exemplo
                );

                await _history.CreateAsync(history);

                if (price <= alert.MaxPrice)
                {
                    await _email.SendEmailAsync(
                        alert.User.Email.Value,
                        "Preço encontrado!",
                        $"Encontramos uma passagem por {price:C}!"
                    );
                }
            }

            await _history.SaveChangesAsync();
        }
    }
}
