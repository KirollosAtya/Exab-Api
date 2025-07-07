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

    public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken)
    {
        var list = await _dbSet.Where(predicate).ToListAsync(cancellationToken);

        return list;
    }

    public async Task<bool> Any(Expression<Func<T, bool>> predicate) =>
      await _dbSet.AsNoTracking().AnyAsync(predicate);

    public virtual async Task<List<T>> Get(List<int> ids) =>
        await _dbSet.Where(c => ids.Contains( c.Id)).ToListAsync();

    public virtual async Task<T> Insert(T data ,CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(data,cancellationToken);
        return data;
    }
    public virtual async Task InsertRange(List<T> values) => await _dbSet.AddRangeAsync(values);
    public virtual void Update(T data) => _dbSet.Update(data);
    public virtual void UpdateRange(List<T> values) => _dbSet.UpdateRange(values);


    public virtual void Remove(T data) => _dbSet.Remove(data);
    public virtual void RemoveRange(List<T> values) => _dbSet.RemoveRange(values);

    public virtual async Task<int> Count() => await _dbSet.CountAsync();

    protected virtual string[] Filters()
    {
        return [];
    }

  
}
