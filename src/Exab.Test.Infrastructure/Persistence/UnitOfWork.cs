using Exab.Test.Application.Interface;
using Exab.Test.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Exab.Test.Infrastructure.Persistence;
public class UnitOfWork(ITestDbContext testDbContext) :IUnitOfWork
{
    private readonly ITestDbContext _testDbContext = testDbContext;
    private bool _disposed = false;
    private ICategoryRepository? _category;
    private IProductRepository? _product;


    public ICategoryRepository Categories => _category ??= new CategoryRepository(testDbContext);
    public IProductRepository Product => _product ??= new ProductRepository(testDbContext);



    public DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return _testDbContext.Set<TEntity>();
    }
    public EntityEntry Entry<TEntity>(object entity) where TEntity : class
    {
        return _testDbContext.Entry<TEntity>(entity);
    }

    public async Task CommitAsync( CancellationToken cancellationToken)
    {
        await _testDbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _testDbContext?.Dispose();
            }
            _disposed = true;
        }
    }

    ~UnitOfWork() => Dispose(false);
}

