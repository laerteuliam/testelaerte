using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public sealed class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Pedido> GetByIdAsync(int id)
        {
            return _dbContext.Set<Pedido>()
                .Include(x => x.Cliente)
                .SingleAsync(x => x.Id == id);
        }

        public override Task<List<Pedido>> GetAsync()
        {
            return _dbContext.Set<Pedido>()
                .Include(x => x.Cliente)
                .ToListAsync();
        }
    }
}
