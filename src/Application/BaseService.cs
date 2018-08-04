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
        
        public virtual int Add(TEntity t)
        {
            return _repository.Add(t);
        }

        public virtual List<TEntity> Get()
        {
            return _repository.Get();
        }
        
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        
        public virtual void Update(int id, TEntity t)
        {
            _repository.Update(id, t);
        }
    }
}
