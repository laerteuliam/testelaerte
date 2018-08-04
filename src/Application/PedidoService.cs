using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using System.Linq;

namespace Application.Services
{
    public sealed class PedidoService : BaseService<Pedido>
    {
        private readonly IClienteRepository _clienteRepository;
        public PedidoService(IRepository<Pedido> repository, IClienteRepository clienteRepository) : base(repository){
            this._clienteRepository = clienteRepository;
        }

        public override int Add(Pedido t)
        {
            var cliente = _clienteRepository.GetByCpf(t.Cliente.Cpf);
            if (cliente != null) t.Cliente.SetId(cliente.Id);
            return base.Add(t);
        }

        public override void Update(int id, Pedido t)
        {
            var cliente = _clienteRepository.GetByCpf(t.Cliente.Cpf);
            if (cliente != null) t.Cliente.SetId(cliente.Id);
            base.Update(id,t);
        }
    }
}
