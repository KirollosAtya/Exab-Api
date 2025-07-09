using Exab.Test.Application.Common.Interfaces;
using Exab.Test.Domain.Entities.UserManagement;

namespace Exab.Test.Infrastructure.Persistence;

public  class TestDbContext(DbContextOptions options) : DbContext(options) ,ITestDbContext,IDisposable
{
   

    public virtual DbSet<Category> Categories => Set<Category>();
    public virtual DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public EntityEntry Entry<TEntity>(object entity) where TEntity : class => base.Entry(entity);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return base.DisposeAsync();
    }
}