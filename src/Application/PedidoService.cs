using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using System.Linq;

namespace Application.Services
{
    public sealed class PedidoService : BaseService<Pedido>
    {
        private IRepository<Pedido> repository;
        public PedidoService(IRepository<Pedido> repository) : base(repository){}
    }
}
