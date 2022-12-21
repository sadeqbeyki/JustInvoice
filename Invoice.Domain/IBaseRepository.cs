using AppFramework;

namespace Invoice.Domain;

public interface IBaseRepository<TKey, TEntity> where TEntity : BaseEntity, new()
{
    TEntity Create(TEntity entity);
    TEntity? Get(TKey key);
    IQueryable<TEntity> GetAll();
    TEntity Update(TEntity entity);
    void Delete(long key);
    void SaveChanges();

}
