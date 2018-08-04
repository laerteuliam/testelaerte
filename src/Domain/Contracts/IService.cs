namespace Domain.Contracts
{
    using Domain.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IService<TEntity>
        where TEntity:IEntity
    {
        int Add(TEntity t);
        void Update(int id,TEntity t);
        List<TEntity> Get();
        TEntity GetById(int id);
    }
}
