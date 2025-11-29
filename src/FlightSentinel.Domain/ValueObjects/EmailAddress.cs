using FlightSentinel.Domain.Exceptions;

namespace FlightSentinel.Domain.ValueObjects
{
    public class EmailAddress
    {
        public string Value { get; }

        public EmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email)) 
            {
                throw new DomainException("O endereço de email não pode ser vazio.");
            }

            if (!email.Contains("@") || !email.Contains(".")) 
            {
                throw new DomainException("O endereço de e-mail é inválido.");
            }

            Value = email.Trim().ToLower();
        }

        public override string ToString() => Value;
    }
}
