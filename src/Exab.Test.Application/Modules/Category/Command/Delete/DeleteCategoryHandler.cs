namespace Exab.Test.Application.Modules.Category.Command.Delete;
public  class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        //Test Git
        var category = await _unitOfWork.Categories.GetById(request.Id, cancellationToken);
        if (category == null)
            return false;

        _unitOfWork.Categories.Remove(category);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}