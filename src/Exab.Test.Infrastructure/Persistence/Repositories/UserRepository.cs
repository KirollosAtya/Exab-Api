using Exab.Test.Domain.Entities.UserManagement;

namespace Exab.Test.Infrastructure.Persistence.Repositories;
public  class UserRepository(ITestDbContext testDbContext) : BaseRepository<User>(testDbContext), IUserRepository
{

}
