

using Exab.Test.Application.Common.Interfaces;

namespace Exab.Test.Infrastructure.Persistence.Repositories;
public  class ProductRepository(ITestDbContext testDbContext  ): BaseRepository<Product>(testDbContext), IProductRepository
{
}
