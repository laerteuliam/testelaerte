namespace Domain.Contracts
{
    using Domain.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IService<TEntity>
        where TEntity:IEntity
    {
        Task<int> AddAsync(TEntity t);
        Task UpdateAsync(TEntity t);
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
