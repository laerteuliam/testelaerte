using System;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Models
{
    public class Cliente:IEntity
    {
       
        public Cliente(string nome, string email, string cpf)
        {
            ValidarNome(nome);
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public Cliente(int id, string nome, string email, string cpf)
        {
            ValidarNome(nome);
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new DomainException("Nome inválido.");
            if (nome.Length < 3) throw new DomainException("Nome precisa ter no mínimo 3 caracteres.");
            if (nome.Length > 100) throw new DomainException("Nome precisa ter no máximo 100 caracteres.");
        }

        public void SetId(int value)
        {
            ValidarId(value);
            Id = value;
        }

        private void ValidarId(int id)
        {
            if (id < 0) throw new DomainException("Id inválido.");
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
    }
}
