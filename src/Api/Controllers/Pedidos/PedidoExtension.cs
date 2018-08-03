using System;
using Domain.Models;

namespace Api.Controllers.Pedidos
{
    public static class PedidoExtension
    {
        public static Pedido ToEntity(this PedidoDto dto)
        {
            var cliente = new Cliente(dto.NomeCliente, dto.Email, dto.Cpf);
            return new Pedido(cliente,dto.ValorTotal,DateTime.Now);
        }

        public static PedidoViewModel ToViewModel(this Pedido pedido)
        {
            return new PedidoViewModel
            {
                Id = pedido.Id,
                Cpf = pedido.Cliente.Cpf,
                NomeCliente = pedido.Cliente.Nome,
                Email = pedido.Cliente.Email,
                ValorTotal = pedido.ValorTotal,
                DataPedido = pedido.DataPedido
            };
        }
    }
}
