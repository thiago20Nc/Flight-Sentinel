namespace FlightSentinel.Domain.Entities
{
    public class PriceCheckHistory
    {
        public Guid HistoryId { get; set; }

        //FK 
        public Guid AlertId { get; set; }
        public PriceAlert Alert { get; set; }
        
        public decimal FoundPrice { get; set; }
        public DateTime FoundAt { get; set; }
        public  string Airline { get; set; }
    }
}
