namespace Exab.Test.Application.Modules.Category.Command.Delete;
public record class DeleteCategoryCommand(int Id ) : IRequest<bool>;

