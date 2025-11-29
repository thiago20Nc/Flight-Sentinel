using FlightSentinel.Domain.Exceptions;
using FlightSentinel.Domain.ValueObjects;

namespace FlightSentinel.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public EmailAddress Email { get; set; }
        public string PasswordHash { get; set; }

        //Relacionamentos
        public ICollection<PriceAlert> Alerts { get; set; }

        public User(string name, EmailAddress email, string passwordHash) 
        { 
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            UserId = Guid.NewGuid();
        }

        public void SetName(string name) 
        {
            if (string.IsNullOrEmpty(name)) 
            {
                throw new DomainException("O nome é obrigatório.");
            }

            if (name.Length < 8) 
            {
                throw new DomainException("O nome não pode ter menos de 8 caracteres.");
            }

            if (name.Length > 100) 
            {
                throw new DomainException("O nome não pode ter mais de 100 caracteres.");
            }

            Name = name.Trim();
        }

        public void ChangePassword(string newHash) 
        {
            if (string.IsNullOrEmpty(newHash)) 
            {
                throw new DomainException("Senha inválida");
            }

            PasswordHash = newHash;
        }
    }
}
