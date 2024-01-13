using JI.Domain.Common;
using System.Linq.Expressions;

namespace JI.DomainContracts.Common;

public interface IRepository<T> where T : EntityBase<T>
{
    T GetById(T id);

    IEnumerable<T> List();

    IEnumerable<T> List(Expression<Func<T, bool>> predicate);

    void Insert(T entity);

    void Update(T entity);

    void Delete(T entity);
}
