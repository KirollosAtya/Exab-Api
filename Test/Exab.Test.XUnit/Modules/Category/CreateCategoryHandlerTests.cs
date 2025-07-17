
using Exab.Test.Application.Common.Interfaces;
using Exab.Test.Application.Modules.Categories.Command.Create;
using Moq;

namespace Exab.Test.XUnit.Modules.Category;
public class CreateCategoryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ICategoryRepository> _categoryRepoMock;
    private readonly CreateCategoryHandler _handler;

    public CreateCategoryHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _categoryRepoMock = new Mock<ICategoryRepository>();

        
        _unitOfWorkMock.SetupGet(u => u.Categories).Returns(_categoryRepoMock.Object);

        _handler = new CreateCategoryHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Insert_Category_And_Return_Id()
    {
       
        var command = new CreateCategoryCommand
        {
            Name = "Books",
            Description = "Books Category",
            ImageUrl = "https://example.com/img.jpg"
        };

        var category = new Exab.Test.Domain.Entities.Category
        {
            Id = 123, 
            Name = command.Name,
            Description = command.Description,
            ImageUrl = command.ImageUrl
        };

        _unitOfWorkMock
            .Setup(u => u.CommitAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
     
        var result = await _handler.Handle(command, CancellationToken.None);


        Assert.Equal(0, result);
      
    }
}
