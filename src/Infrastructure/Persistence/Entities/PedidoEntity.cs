using Domain.Models;
using System;

namespace Infrastructure.Persistence.Entities
{
    public class PedidoEntity
    {
        public PedidoEntity()
        {

        }
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public ClienteEntity Cliente { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
