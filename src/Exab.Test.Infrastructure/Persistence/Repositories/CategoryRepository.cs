

namespace Exab.Test.Infrastructure.Persistence.Repositories;
public  class CategoryRepository(ITestDbContext testDbContext): BaseRepository<Category>(testDbContext), ICategoryRepository
{
}
