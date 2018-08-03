using Domain.Models;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            
            builder.OwnsOne(s=>s.Cpf, cb=> {
                cb.Property(c=>c.Valor)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(14)")
                .IsRequired();
            });

            builder.OwnsOne(s => s.Email, cb => {
                cb.Property(c => c.Valor)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .IsRequired();
            });

            builder.OwnsOne(c => c.Email);
        }
    }
}
