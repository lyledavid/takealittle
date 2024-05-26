using Moq;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Features.Products.Commands.UpdateProduct;
using Takealittle.Application.UnitTests.Products.Commands.TestUtils;
using Takealittle.Domain.Entities;

namespace Takealittle.Application.UnitTests.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandlerTests
{
    private readonly UpdateProductCommand.UpdateProductCommandHandler _handler;
    private readonly Mock<IProductRepository> _mockProductRepository;

    public UpdateProductCommandHandlerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _handler = new UpdateProductCommand.UpdateProductCommandHandler(_mockProductRepository.Object);
    }
    
    [Fact]
    public async Task HandleUpdateProductCommand_WhenProductIsValid_ShouldUpdateAndReturnProduct()
    {
        // Arrange
        var updateProductCommand = UpdateProductCommandUtils.UpdateCommand();
        _mockProductRepository.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product());
        
        // Act
        var result = await _handler.Handle(updateProductCommand, CancellationToken.None);
        
        // Assert
        _mockProductRepository.Verify(p => p.UpdateAsync(It.Is<Product>(x => 
            x.Description == result.Data.Description &&
        x.Name == result.Data.Name &&
        x.Barcode == result.Data.Barcode &&
        x.Price == result.Data.Price
            )));
    }
}