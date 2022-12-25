using AppFramework;
using System.Linq.Expressions;

namespace Invoice.Domain;

public interface IBaseRepository<TKey, TEntity> where TEntity : BaseEntity, new()
{
    TEntity Create(TEntity entity);
    TEntity? Get(TKey key);
    IQueryable<TEntity> GetAll();
    TEntity Update(TEntity entity);
    void Delete(long key);
    void SaveChanges();
    void PreEdit(IQueryable<TEntity> entities);
    bool Exists(Expression<Func<TEntity, bool>> expression);


}
