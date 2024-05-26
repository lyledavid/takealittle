using FluentAssertions;
using MapsterMapper;
using Moq;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Features.Products.Commands.CreateProduct;
using Takealittle.Application.Features.Products.Queries.GetProduct;
using Takealittle.Application.UnitTests.Products.Commands.TestUtils;
using Takealittle.Domain.Entities;


public class GetProductByIdQueryHandlerTests
{
    private readonly GetProductQuery.GetProductByIdQueryHandler _handler;
    private readonly Mock<IProductRepository> _mockProductRepository;

    public GetProductByIdQueryHandlerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _handler = new GetProductQuery.GetProductByIdQueryHandler(_mockProductRepository.Object);
    }
    
    [Fact]
    public async Task HandleGetProductByIdQuery_WhenProductIsValid_ShouldReturnProduct()
    {
        // Arrange
        var getProductByIdCommand = new GetProductQuery { Id = 1 };
        var product = new Product
        {
            Id = 1,
            Name = "Product 1",
            Barcode = "123456",
            Description = "Description",
            Price = 100
        };
        _mockProductRepository.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
        
        // Act
        var result = await _handler.Handle(getProductByIdCommand, CancellationToken.None);
        
        // Assert
        result.Errors.Should().BeNullOrEmpty();
        _mockProductRepository.Verify(p => p.GetByIdAsync(1), Times.Once);
    }
}