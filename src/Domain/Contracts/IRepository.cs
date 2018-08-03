using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRepository<TEntity>
        where TEntity:IEntity
    {
        Task<int> AddAsync(TEntity t);
        Task UpdateAsync(TEntity t);
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
