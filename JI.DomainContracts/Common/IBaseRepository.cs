﻿using JI.Domain.Common;
using System.Linq.Expressions;

namespace JI.DomainContracts.Common;

public interface IBaseRepository<TKey, TEntity> where TEntity : EntityBase, new()
{
    TEntity Create(TEntity entity);
    TEntity? Get(TKey key);
    IQueryable<TEntity> GetAll();
    TEntity Update(TEntity entity);
    void Delete(long key);
    void SaveChanges();
    bool Exists(Expression<Func<TEntity, bool>> expression);


}
