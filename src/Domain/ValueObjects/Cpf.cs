using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public sealed class Cpf
    {
        public Cpf()
        {
            //Apenas p/ o EF
        }
        public string Valor { get; private set; }

        public Cpf(string valor)
        {
            if (!Validar(valor)) throw new DomainException("CPF inválido.");
            this.Valor = valor;
        }

        public static implicit operator Cpf(string valor)
        {
            return new Cpf(valor);
        }

        public static implicit operator string(Cpf cpf)
        {
            return cpf.Valor;
        }
        
        public bool Validar(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

    }
}
