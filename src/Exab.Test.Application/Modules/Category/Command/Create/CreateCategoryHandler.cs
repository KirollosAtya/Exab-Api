using Exab.Test.Application.Interface;

namespace Exab.Test.Application.Modules.Category.Command.Create;
public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        
        var category = new Exab.Test.Domain.Entities.Category
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl
        };

        await _unitOfWork.Categories.Insert(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return category.Id;
    }
}
