using MediatR;

namespace Exab.Test.Application.Modules.Categories.Command.Create;
public  class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; } 
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
