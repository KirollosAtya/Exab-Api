using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Modules.Category.Query.GetById;
public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Exab.Test.Domain.Entities.Category?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Exab.Test.Domain.Entities.Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Categories.GetById(request.Id, cancellationToken,false);
    }
}
