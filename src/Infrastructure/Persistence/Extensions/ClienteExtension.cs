using Domain.Models;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Extensions
{
    internal static class ClienteExtension
    {
        public static ClienteEntity ToEntity(this Cliente entity)
        {
            return new ClienteEntity
            {
                Cpf = entity.Cpf,
                Email = entity.Email,
                Id = entity.Id,
                Nome = entity.Nome
            };
        }

        public static Cliente ToModel(this ClienteEntity entity)
        {
            return new Cliente(entity.Id,entity.Nome, entity.Email, entity.Cpf);
        }
    }
}
