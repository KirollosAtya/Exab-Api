

namespace Exab.Test.Application.Modules.Categories.Query.GetById;
public  record GetCategoryByIdQuery(int Id) : IRequest<Category?>;

