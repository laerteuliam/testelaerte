using System;
namespace Api.Controllers.Pedidos
{
    public class PedidoDto
    {
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
