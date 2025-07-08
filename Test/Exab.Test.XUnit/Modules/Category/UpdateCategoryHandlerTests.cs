using Exab.Test.Application.Interface;
using Exab.Test.Application.Modules.Categories.Command.Update;
using Exab.Test.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.XUnit.Modules.Category;
public  class UpdateCategoryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UpdateCategoryHandler _handler;
    private readonly Mock<ICategoryRepository> _categoryRepoMock;

    public UpdateCategoryHandlerTests()
    {
      
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _categoryRepoMock = new Mock<ICategoryRepository>();


        _unitOfWorkMock.SetupGet(u => u.Categories).Returns(_categoryRepoMock.Object);

        _handler = new UpdateCategoryHandler(_unitOfWorkMock.Object);
    }
    [Fact]
    public async Task Handle_ReturnTrue_WhenCategoryExists()
    {
        var request = new UpdateCategoryCommand
        {
            Id = 5,
            Name = "Updated test",
            Description = "Updated Test",
            ImageUrl = "image.jpg"
        };

        var existingCategory = new Exab.Test.Domain.Entities.Category
        {
            Id = 5,
            Name = "Old Name",
            Description = "Old",
            ImageUrl = "old.jpg"
        };

     
        _categoryRepoMock
            .Setup(r => r.GetById(request.Id, It.IsAny<CancellationToken>(), false))
            .ReturnsAsync(existingCategory);

        var result = await _handler.Handle(request, CancellationToken.None);


        Assert.True(result);
        Assert.Equal("Updated test", existingCategory.Name);
    }
    [Fact]
    public async Task Handle_ReturnFalse_WhenCategoryDoesNotExist()
    {
       
        var request = new UpdateCategoryCommand
        {
            Id = 2,
            Name = "Does Not Test"
        };

        var result = await _handler.Handle(request, CancellationToken.None);
      
        Assert.False(result);
      
    }
}
