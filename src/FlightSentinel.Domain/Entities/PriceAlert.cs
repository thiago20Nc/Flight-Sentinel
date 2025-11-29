using FlightSentinel.Domain.Enums;
using FlightSentinel.Domain.Exceptions;
using FlightSentinel.Domain.ValueObjects;

namespace FlightSentinel.Domain.Entities
{
    public class PriceAlert
    {
        public Guid AlertId { get; private set; }

        // FK
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        
        public AirportCode OriginAirport { get; private set; }
        public AirportCode DestinationAirport { get; private set; }
        
        public DateTime OriginDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        
        public decimal MaxPrice { get; private set; }
        public AlertStatus Status { get; private set; }

        // Relacionamento com histórico
        public ICollection<PriceCheckHistory> History { get; set; }

        protected PriceAlert() { } //EF

        public PriceAlert(Guid userId, AirportCode origin, AirportCode destination, 
            DateTime originDate, DateTime returnDate, decimal maxPrice)
        {
            if(maxPrice <= 0) 
            {
                throw new DomainException("O preço máximo não pode ser maior que zero.");
            }

            UserId = userId;
            OriginAirport = origin;
            DestinationAirport = destination;
            OriginDate = originDate;
            ReturnDate = returnDate;
            MaxPrice = maxPrice;

            AlertId = Guid.NewGuid();
            Status = AlertStatus.Active;
        }

        public void Activate() => Status = AlertStatus.Active;
        public void Deactivate() => Status = AlertStatus.Inactive;

        public void UpdateMaxPrice(decimal newPrice) 
        {
            if (newPrice <= 0) 
            {
                throw new DomainException("O preço precisa ser positivo");
            }

            MaxPrice = newPrice;
        }
    }
}
