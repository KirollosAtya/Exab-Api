namespace Exab.Test.Application.Modules.Categories.Command.Update;
public  class UpdateCategoryCommand : IRequest<bool>
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
