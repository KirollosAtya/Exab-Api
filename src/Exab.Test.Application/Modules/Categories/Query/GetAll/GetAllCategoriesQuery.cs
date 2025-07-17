
using Exab.Test.Application.Common.Models;

namespace Exab.Test.Application.Modules.Categories.Query.GetAll;
public  class GetAllCategoriesQuery : PaginatedRequest, IRequest<PaginatedResult<Category>>
{

}
