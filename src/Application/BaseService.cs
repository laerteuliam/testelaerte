using Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity:IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<int> AddAsync(TEntity t)
        {
            return  _repository.AddAsync(t);
        }

        public virtual Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public virtual Task<List<TEntity>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public virtual Task UpdateAsync(TEntity t)
        {
            return _repository.UpdateAsync(t);
        }
    }
}
