

namespace Exab.Test.Infrastructure.Persistence.Repositories;
public  class ProductRepository(ITestDbContext testDbContext  ):    BaseRepository<Product>(testDbContext), IProductRepository
{
}
