using Domain.Contracts;
using Domain.Models;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Persistence
{
    public sealed class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _dbContext;

        public ClienteRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Cliente GetByCpf(string cpf)
        {
            var entity = _dbContext.Set<ClienteEntity>().SingleOrDefault(x => x.Cpf == cpf);
            return (entity != null ? entity.ToModel() : null);
        }
    }
}
