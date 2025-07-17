using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Exab.Test.Application.Common.Interfaces;
public  interface ITestDbContext : IDisposable 
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry Entry<TEntity>(object entity) where TEntity : class;

}
