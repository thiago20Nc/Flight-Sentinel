using FlightSentinel.Domain.Exceptions;

namespace FlightSentinel.Domain.ValueObjects
{
    public class AirportCode
    {
        public string Value { get; }

        public AirportCode(string value)
        {
            if (string.IsNullOrEmpty(value)) 
            { 
                throw new DomainException("O código do aeroporto é obrigatório.");
            }

            if (value.Length != 3) 
            {
                throw new DomainException("O código do aeroporto precisa ter 3 letras.");
            }

            Value = value.ToUpper();
        }

        public override string ToString() => Value;
    }
}
