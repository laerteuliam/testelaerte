using Bogus;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Bogus.Extensions.Brazil;

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
                List<Pedido> pedidoFake = new Faker<Pedido>("pt_BR")
                    .CustomInstantiator(
                        f => new Pedido(
                            new Cliente(f.Person.FullName, 
                            f.Person.Email 
                            ,f.Person.Cpf())
                            , f.Random.Double(1, 1000), f.Date.Recent(3)))
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
