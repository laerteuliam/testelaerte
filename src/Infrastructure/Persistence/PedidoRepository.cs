using Domain.Contracts;
using Domain.Models;
using Infrastructure.Persistence.Entities;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public sealed class PedidoRepository : IRepository<Pedido>
    {
        private readonly AppDbContext _dbContext;

        public PedidoRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public int Add(Pedido t)
        {
            var entity = t.ToEntity();
            _dbContext
                .Set<PedidoEntity>()
                .Add(entity);

            _dbContext.SaveChanges();
            return entity.Id;
        }
        
        public List<Pedido> Get()
        {
            return _dbContext.Set<PedidoEntity>()
                    .Include(x=>x.Cliente)
                    .ToList()
                    .ConvertAll(x => x.ToModel());
        }

        public Pedido GetById(int id)
        {
            return _dbContext
                    .Set<PedidoEntity>()
                    .Include(x => x.Cliente)
                    .Single(x => x.Id == id)
                    .ToModel();
        }

        public async Task UpdateAsync(Pedido t)
        {
            var entity = GetById(t.Id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Set<PedidoEntity>().Update(t.ToEntity());
            await _dbContext.SaveChangesAsync();
        }

        public void Update(int id, Pedido t)
        {
            var entity = _dbContext.Set<PedidoEntity>().Single(x => x.Id==id);

            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Entry(entity.Cliente).State = EntityState.Detached;
            
            var updateEntity = t.ToEntity();
            updateEntity.Id = id;

            _dbContext.Set<PedidoEntity>().Update(updateEntity);
            _dbContext.SaveChangesAsync();
        }
    }
}
