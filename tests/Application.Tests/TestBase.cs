using Bogus;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Bogus.Extensions.Brazil;
using Infrastructure.Persistence.Entities;

namespace Application.Tests
{
    public class TestBase : IDisposable
    {
        protected AppDbContext _dbInMemory;
        
        public TestBase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseInMemoryDatabase(databaseName: "TesteLaerteDb")
                        .Options;
            _dbInMemory = new AppDbContext(options);
            Seed();
        }

        private void Seed()
        {
            try
            {
                List<PedidoEntity> pedidoFake = new Faker<PedidoEntity>("pt_BR")
                    .CustomInstantiator(
                        f => new PedidoEntity
                        {
                            Cliente = new ClienteEntity
                            {
                                Cpf = f.Person.Cpf(),
                                Email = f.Person.Email,
                                Nome = f.Person.FullName
                            },
                            DataPedido = f.Date.Recent(3),
                            ValorTotal = f.Random.Double(1, 1000)
                        })
                        .Generate(5);

                pedidoFake.ForEach(x => _dbInMemory.Add(x));
                _dbInMemory.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _dbInMemory = null;
        }
    }
}
