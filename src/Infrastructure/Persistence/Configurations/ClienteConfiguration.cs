using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Cpf).IsUnique();
            builder.Property(s => s.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(s => s.Email).HasMaxLength(100).IsRequired();
        }
    }
}
