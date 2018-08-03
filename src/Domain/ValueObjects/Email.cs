using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed class Email
    {
        public Email()
        {
            //Apenas p/ o EF
        }
        public string Valor { get; private set; }

        public Email(string valor)
        {
            if (!Validar(valor)) throw new DomainException("Email inválido.");
            this.Valor = valor;
        }

        public static implicit operator Email(string valor)
        {
            return new Email(valor);
        }

        public static implicit operator string(Email email)
        {
            return email.Valor;
        }

        public bool Validar(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }
    }
}
