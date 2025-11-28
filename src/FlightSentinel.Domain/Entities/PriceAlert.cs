namespace FlightSentinel.Domain.Entities
{
    public class PriceAlert
    {
        public Guid AlertId { get; set; }

        // FK
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        
        public DateTime OriginDate { get; set; }
        public DateTime ReturnDate { get; set; }
        
        public decimal MaxPrice { get; set; }
        public string Status { get; set; }

        // Relacionamento com histórico
        public ICollection<PriceCheckHistory> History { get; set; }
    }
}
