using FluentAssertions;
using MapsterMapper;
using Moq;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Features.Products.Commands.CreateProduct;
using Takealittle.Application.UnitTests.Products.Commands.TestUtils;

namespace Takealittle.Application.UnitTests.Products.Commands.CreateProduct;

public class CreateProductCommandHandlerTests
{
    private readonly CreateProductCommandHandler _handler;
    private readonly Mock<IProductRepository> _mockProductRepository;

    public CreateProductCommandHandlerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _handler = new CreateProductCommandHandler(_mockProductRepository.Object, new Mapper());
    }
    
    [Fact]
    public async Task HandleCreateProductCommand_WhenProductIsValid_ShouldCreateAndReturnProduct()
    {
        // Arrange
        var createProductCommand = CreateProductCommandUtils.CreateCommand();
        
        // Act
        var result = await _handler.Handle(createProductCommand, CancellationToken.None);
        
        result.Errors.Should().BeNullOrEmpty();
        _mockProductRepository.Verify(p => p.AddAsync(result.Data), Times.Once);
    }
}