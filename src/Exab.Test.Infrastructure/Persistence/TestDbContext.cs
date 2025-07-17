using Exab.Test.Application.Common.Interfaces;
using Exab.Test.Domain.Constants;
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
        SeedData(modelBuilder);
    }
    public override ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return base.DisposeAsync();
    }
    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Roles
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 4, Name = "Admin", Description = "Full system access", IsActive = true },
            new Role { Id = 5, Name = "Manager", Description = "Management level access", IsActive = true },
            new Role { Id = 6, Name = "User", Description = "Basic user access", IsActive = true }
        );

        // Seed Admin Permissions
        var adminPermissions = new List<RolePermission>();
        var permissionId = 4;

        foreach (var permission in Permissions.GetAllPermissions())
        {
            var parts = permission.Split('.');
            adminPermissions.Add(new RolePermission
            {
                Id = permissionId++,
                RoleId = 1, // Admin role
                Resource = parts[0],
                Action = parts[1],
                Permission = permission,

            });
        }

        modelBuilder.Entity<RolePermission>().HasData(adminPermissions);

        // Seed some Manager permissions
        modelBuilder.Entity<RolePermission>().HasData(

            new RolePermission { Id = permissionId++, RoleId = 2, Resource = "Category", Action = "Read", Permission = "Category.Read" },
            new RolePermission { Id = permissionId++, RoleId = 2, Resource = "Category", Action = "Create", Permission = "Category.Create" },
            new RolePermission { Id = permissionId++, RoleId = 2, Resource = "Category", Action = "Update", Permission = "Category.Update" },
            new RolePermission { Id = permissionId++, RoleId = 2, Resource = "Category", Action = "Delete", Permission = "Category.Delete" }
        );

        // Seed basic User permissions
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission { Id = permissionId++, RoleId = 3, Resource = "Category", Action = "Read", Permission = "Products.Read" }
        );
    }
}