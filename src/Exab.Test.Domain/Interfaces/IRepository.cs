using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Domain.Interfaces;
public  interface IRepository<T> where T :class 
{
    Task<T?> GetById(int id, CancellationToken cancellationToken, bool noTracking = false);
    
    Task<List<T>> Get(List<int> ids);
    Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> Any(Expression<Func<T, bool>> predicate);
    Task<T> Insert(T data,CancellationToken cancellationToken);
    Task InsertRange(List<T> values);
    void Update(T data);
    void UpdateRange(List<T> values);

    void Remove(T data);
    void RemoveRange(List<T> values);

    Task<int> Count();
}
