using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public AppDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
        }
        
        DbSet<PedidoEntity> Pedidos { get; set; }
        DbSet<ClienteEntity> Clientes { get; set; }
    }
}
