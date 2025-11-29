namespace FlightSentinel.Domain.Entities
{
    public class PriceCheckHistory
    {
        public Guid HistoryId { get; private set; }

        //FK 
        public Guid AlertId { get; private set; }
        public PriceAlert Alert { get; private set; }
        
        public decimal FoundPrice { get; private set; }
        public DateTime FoundAt { get; private set; }
        public  string Airline { get; private set; }

        protected PriceCheckHistory() { } //EF

        public PriceCheckHistory(Guid alertId, decimal foundPrice, string airline) 
        { 
            AlertId = alertId;
            FoundPrice = foundPrice;
            Airline = airline;
            FoundAt = DateTime.UtcNow;
            HistoryId = Guid.NewGuid();
        }
    }
}
