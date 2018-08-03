using Domain.Contracts;
using Domain.Exceptions;
using System;

namespace Domain.Models
{
    public class Pedido : IEntity
    {
        public Pedido()
        {
            //Declarado somente p/ o EF.
        }
        public int Id { get; private set; }
        public double ValorTotal { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime DataPedido { get; private set; }
       
        public Pedido(int id, Cliente cliente, double valorTotal, DateTime dataPedido)
        {
            ValidarId(id);
            SetCliente(cliente);
            SetValorTotal(valorTotal);
            Id = id;
            DataPedido = dataPedido;
        }

        public Pedido(Cliente cliente, double valorTotal, DateTime dataPedido)
        {
            SetCliente(cliente);
            SetValorTotal(valorTotal);
            DataPedido = dataPedido;
        }

        public void SetCliente(Cliente value)
        {
            Cliente = value;
        }

        public void SetValorTotal(double value)
        {
            ValorTotal = value;
        }

        private void ValidarId(int id)
        {
            if (id < 0) throw new DomainException("Id inválido.");
        }
    }
}
