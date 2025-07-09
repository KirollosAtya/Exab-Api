using Exab.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Common.Interfaces;
public  interface IRepository<T> where T :class 
{
    Task<T?> GetById(int id, CancellationToken cancellationToken, bool noTracking = false);
   
    Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<T> Insert(T data,CancellationToken cancellationToken);
    void Update(T data);

    void Remove(T data);
    Task<int> Count();

    IQueryable<T> GetQueryable();
}
