using Exab.Test.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Modules.Category.Query.GetAll;
public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Exab.Test.Domain.Entities.Category>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoriesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Exab.Test.Domain.Entities.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Categories.GetList(c => true,cancellationToken);
        return result.ToList();
    }
}
