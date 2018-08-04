using Domain.Models;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Extensions
{
    internal static class PedidoExtension
    {
        public static PedidoEntity ToEntity(this Pedido pedido)
        {
            return new PedidoEntity
            {
                Cliente = pedido.Cliente.ToEntity(),
                DataPedido = pedido.DataPedido,
                Id = pedido.Id,
                ValorTotal = pedido.ValorTotal
            };
        }

        public static Pedido ToModel(this PedidoEntity entity)
        {
            return new Pedido(entity.Id, entity.Cliente.ToModel(), entity.ValorTotal, entity.DataPedido);
        }
    }
}
