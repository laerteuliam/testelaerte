using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly AppDbContext _dbContext;
        
        public BaseRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual int Add(TEntity t)
        {
            _dbContext.Set<TEntity>();
            _dbContext.Add(t);
            _dbContext.SaveChanges();

            return t.Id;
        }

        public virtual async Task<int> AddAsync(TEntity t)
        {
            _dbContext.Set<TEntity>();
            _dbContext.Add(t);
            await _dbContext.SaveChangesAsync();
            return t.Id;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = GetById(id);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>()
            .AsNoTracking()
            .Single(x => x.Id == id);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().SingleAsync(x => x.Id == id);
        }

        public virtual IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public virtual async Task<List<TEntity>> GetAsync()
        {
            return await Get().ToListAsync();
        }
        
        public void Update(TEntity t)
        {
            _dbContext.Set<TEntity>().Update(t);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(TEntity t)
        {
            var entity = await GetByIdAsync(t.Id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Set<TEntity>().Update(t);
            await _dbContext.SaveChangesAsync();
        }
    }
}
