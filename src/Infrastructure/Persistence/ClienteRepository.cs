using Domain.Models;

namespace Infrastructure.Persistence
{
    public sealed class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
