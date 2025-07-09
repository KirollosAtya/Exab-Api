using Exab.Test.Application.Common.Interfaces;

namespace Exab.Test.Application.Modules.Categories.Query.GetAll;
public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PaginatedResult<Category>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoriesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginatedResult<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Categories.GetQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(c => c.Name.Contains(request.Search)||c.Description.Contains(request.Search));
        }
        query = request.SortBy?.ToLower() switch
        {
            "name" => request.IsDescending
                            ? query.OrderByDescending(c => c.Name)
                            : query.OrderBy(c => c.Name),

            "description" => request.IsDescending
                            ? query.OrderByDescending(c => c.Description)
                            : query.OrderBy(c => c.Description),

            _ => request.IsDescending
                            ? query.OrderByDescending(c => c.Id)
                            : query.OrderBy(c => c.Id)
        };
        var totalCount = await query.CountAsync(cancellationToken);
        var Category = await query
                                        .Skip((request.PageNumber - 1) * request.PageSize)
                                        .Take(request.PageSize)
                                        .ToListAsync(cancellationToken);

        return    new PaginatedResult<Exab.Test.Domain.Entities.Category>(Category, totalCount, request.PageNumber, request.PageSize);

    }
}
