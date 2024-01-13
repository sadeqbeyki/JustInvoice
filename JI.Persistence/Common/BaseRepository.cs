using JI.Domain.Common;
using JI.DomainContracts.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JI.Persistence.Common;

public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity>
    where TEntity : EntityBase<TKey>, new()
{
    private readonly DbContext _dbContext;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TEntity Create(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }
    public TEntity Get(TKey key)
    {
        return _dbContext.Find<TEntity>(key);
    }
    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsQueryable();
    }
    public TEntity Update(TEntity entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();

        return entity;
    }
    public void SaveChanges()
    {
        _dbContext.SaveChangesAsync();
    }
    public void Delete(TKey key)
    {
        TEntity entity = new()
        {
            Id = key
        };
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
    }
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Any(expression);
    }
}
