namespace Exab.Test.Application.Modules.Category.Command.Update;
public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetById(request.Id, cancellationToken, false);
        if (category == null)
            return false;
        //Here Use Mapping 
        category.Name = request.Name;
        category.Description = request.Description;
        category.ImageUrl = request.ImageUrl;

        _unitOfWork.Categories.Update(category);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}
