using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed class Email
    {
        private readonly string _valor;

        public Email(string valor)
        {
            if (!Validar(valor)) throw new DomainException("Email inválido.");
            this._valor = valor;
        }

        public static implicit operator Email(string valor)
        {
            return new Email(valor);
        }

        public static implicit operator string(Email email)
        {
            return email._valor;
        }

        public bool Validar(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }
    }
}
