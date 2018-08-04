using Application.Services;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class PedidoAnalyzer : TestBase
    {

        [Fact]
        public void GetPedido_PassValidId_ShouldBeReturnObject()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IClienteRepository clienteRepository = new ClienteRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository,clienteRepository);
            PedidoEntity entity = _dbInMemory.Set<PedidoEntity>().AsNoTracking().First();
            Pedido pedido = service.GetById(entity.Id);
            Assert.True(pedido != null);
        }

        [Fact]
        public void GetPedido_PassInvalidId_ShouldBeThrowException()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IClienteRepository clienteRepository = new ClienteRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository, clienteRepository);
            Assert.Throws<InvalidOperationException>(() => service.GetById(0));
        }

        [Fact]
        public void AddPedido_PassValidInput_ShouldBeReturnSuccess()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IClienteRepository clienteRepository = new ClienteRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository, clienteRepository);

            var cliente = new Cliente("Laerte", "laerte.uliam@gmail.com", "191.000.000-00");

            var pedido = new Pedido(cliente, 1000, DateTime.Now);

            var output = service.Add(pedido);
            Assert.True(output > 0);
        }


        [Fact]
        public void AddPedido_PassInvalidInput_ShouldBeThrowException()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IClienteRepository clienteRepository = new ClienteRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository, clienteRepository);

            try
            {
                var cliente = new Cliente("Laerte", "laerte.uliam@gmail.com", "");

                var pedido = new Pedido(cliente, 1000, DateTime.Now);
                service.Add(pedido);
            }
            catch (DomainException ex)
            {
                Assert.True(ex.BusinessMessage != "");
            }
        }

        [Fact]
        public void UpdatePedido_PassValidInput_ShouldBeReturnSuccess()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IClienteRepository clienteRepository = new ClienteRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository, clienteRepository);

            int idPedido = _dbInMemory.Set<PedidoEntity>().First().Id;
            var pedidoToUpdate = service.GetById(idPedido);

            PedidoEntity entity = _dbInMemory.Set<PedidoEntity>().AsNoTracking().First();
            pedidoToUpdate.SetValorTotal(2000);

            try
            {
                service.Update(idPedido, pedidoToUpdate);
            }
            catch (DomainException ex)
            {
                throw new Exception(ex.BusinessMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
