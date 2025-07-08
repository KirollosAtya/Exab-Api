namespace Exab.Test.Application.Modules.Categories.Command.Delete;
public record class DeleteCategoryCommand(int Id ) : IRequest<bool>;

