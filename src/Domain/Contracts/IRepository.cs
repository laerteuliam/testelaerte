using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRepository<TEntity>
        where TEntity:IEntity
    {
        int Add(TEntity t);
        void Update(int id, TEntity t);
        List<TEntity> Get();
        TEntity GetById(int id);
    }
}
