using Invoice.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Invoice.DAL.Persistance;

public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity>
    where TEntity : BaseEntity, new()
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
    public void PreEdit(IQueryable<TEntity> entities)
    {
        _dbContext.RemoveRange(entities);
        _dbContext.SaveChanges();

    }
    public TEntity Update(TEntity entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();

        //_dbContext.Attach(entity);
        //_dbContext.Entry(entity).State = EntityState.Modified;

        return entity;
    }
    public void SaveChanges()
    {
        _dbContext.SaveChangesAsync();
    }
    public void Delete(long key)
    {
        TEntity entity = new()
        {
            Id = key
        };
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();

    //    _dbContext.Attach(entity);
    //    _dbContext.Entry(entity).State = EntityState.Deleted;
    //    _dbContext.SaveChanges();
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Any(expression);
    }
}
