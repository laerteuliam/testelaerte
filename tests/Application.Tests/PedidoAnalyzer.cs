using Application.Services;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Application.Tests
{
    public class PedidoAnalyzer : TestBase
    {

        [Fact]
        public async void GetPedido_PassValidId_ShouldBeReturnObject()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository);
            Pedido model = await _dbInMemory.Set<Pedido>().AsNoTracking().LastAsync();
            Pedido pedido = await service.GetByIdAsync(model.Id);
            Assert.True(pedido != null);
        }

        [Fact]
        public async void GetPedido_PassInvalidId_ShouldBeThrowException()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository);

            await Assert.ThrowsAsync<InvalidOperationException>(
                   () => service.GetByIdAsync(0));
        }

        [Fact]
        public async void AddPedido_PassValidInput_ShouldBeReturnSuccess()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository);

            var cliente = new Cliente("Laerte", "laerte.uliam@gmail.com", "191.000.000-00");

            var pedido = new Pedido(cliente, 1000, DateTime.Now);

            var output = await service.AddAsync(pedido);
            Assert.True(output > 0);
        }


        [Fact]
        public async void AddPedido_PassInvalidInput_ShouldBeThrowException()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository);

            try
            {
                var cliente = new Cliente("Laerte", "laerte.uliam@gmail.com", "");

                var pedido = new Pedido(cliente, 1000, DateTime.Now);
                await service.AddAsync(pedido);
            }
            catch (DomainException ex)
            {
                Assert.True(ex.BusinessMessage != "");
            }
        }

        [Fact]
        public async void UpdatePedido_PassValidInput_ShouldBeReturnSuccess()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository);

            Pedido pedidoToUpdate = await _dbInMemory.Set<Pedido>().AsNoTracking().LastAsync();

            var novoCliente = new Cliente("Laerte", "laerte.uliam@gmail.com", "19100000000");

            pedidoToUpdate.SetCliente(novoCliente);
            pedidoToUpdate.SetValorTotal(2000);

            try
            {
                await service.UpdateAsync(pedidoToUpdate);
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

        [Fact]
        public async void UpdatePedido_PassInvalidInput_ShouldBeThrowException()
        {
            IRepository<Pedido> repository = new PedidoRepository(_dbInMemory);
            IService<Pedido> service = new PedidoService(repository);
            Pedido pedidoToUpdate = await _dbInMemory.Set<Pedido>().AsNoTracking().LastAsync();

            try
            {
                var novoCliente = new Cliente("Laerte", "laerte.uliam@gmail.com", "");

                pedidoToUpdate.SetCliente(novoCliente);
                pedidoToUpdate.SetValorTotal(2000);

                await service.UpdateAsync(pedidoToUpdate);
            }
            catch (DomainException ex)
            {
                Assert.True(ex.BusinessMessage != "");
            }
        }
    }
}
