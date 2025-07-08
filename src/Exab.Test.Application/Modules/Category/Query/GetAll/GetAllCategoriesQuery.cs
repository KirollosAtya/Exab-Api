using Exab.Test.Application.Wrappers;

namespace Exab.Test.Application.Modules.Category.Query.GetAll;
public  class GetAllCategoriesQuery : PaginatedRequest, IRequest<PaginatedResult<Exab.Test.Domain.Entities.Category>>
{

}
