namespace FlightSentinel.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        //Relacionamentos
        public ICollection<PriceAlert> Alerts { get; set; }
    }
}
