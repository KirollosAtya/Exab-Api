
using Exab.Test.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exab.Test.Infrastructure.Persistence.Repositories;
public class BaseRepository<T>(ITestDbContext context) : IRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    public virtual async Task<T?> GetById(int id, CancellationToken cancellationToken, bool noTracking = false)
    {
        var query = _dbSet.AsQueryable();

        if (noTracking)
        {
            query = query.AsNoTracking();
        }

        return await query
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var list = await _dbSet.Where(predicate).ToListAsync(cancellationToken);

        return list;
    }
    public virtual async Task<T> Insert(T data ,CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(data,cancellationToken);
        return data;
    }
    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) =>
            predicate != null ? _dbSet.Where(predicate) : _dbSet;
    public virtual void Update(T data) => _dbSet.Update(data);
    public virtual void Remove(T data) => _dbSet.Remove(data);

    public virtual async Task<int> Count() => await _dbSet.CountAsync();

    public IQueryable<T> GetQueryable()=> _dbSet.AsQueryable();
    
}
