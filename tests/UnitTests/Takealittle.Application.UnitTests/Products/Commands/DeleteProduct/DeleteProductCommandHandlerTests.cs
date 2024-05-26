using Moq;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Features.Products.Commands.DeleteProduct;
using Takealittle.Domain.Entities;

namespace Takealittle.Application.UnitTests.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandlerTests
{
    private readonly DeleteProductCommand.DeleteProductCommandHandler _handler;
    private readonly Mock<IProductRepository> _mockProductRepository;

    public DeleteProductCommandHandlerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _handler = new DeleteProductCommand.DeleteProductCommandHandler(_mockProductRepository.Object);
    }
    
    [Fact]
    public async Task HandleDeleteProductCommand_WhenProductIsValid_ShouldDelete()
    {
        // Arrange
        var deleteProductCommand = new DeleteProductCommand
        {
            Id = 1
        };
        var product = new Product
        {
            Id = 1,
            Name = "Product 1",
            Barcode = "123456",
            Description = "Description",
            Price = 100
        };
        _mockProductRepository.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

        // act
        var result = await _handler.Handle(deleteProductCommand, CancellationToken.None);

        // assert
        _mockProductRepository.Verify(r => r.DeleteAsync(product));
    }
}