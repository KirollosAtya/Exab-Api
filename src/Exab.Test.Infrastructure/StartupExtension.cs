
using Exab.Test.Application.Interface;
using Exab.Test.Infrastructure.Persistence;
using Exab.Test.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exab.Test.Infrastructure;
public static class StartupExtension
{
    public static void ConfigureInfrastructureService(this IServiceCollection services
        , IConfiguration configuration)
    {

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #region DBContext
        services.AddDbContextPool<ITestDbContext, TestDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder =>
                {
                    builder.EnableRetryOnFailure(7, TimeSpan.FromMilliseconds(750), null);

                    builder.MigrationsAssembly(typeof(StartupExtension).Assembly.GetName().Name);
                });
        });
        #endregion
    }
}
