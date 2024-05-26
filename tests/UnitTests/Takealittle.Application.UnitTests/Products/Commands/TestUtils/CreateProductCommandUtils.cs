using Takealittle.Application.Features.Products.Commands.CreateProduct;
using Takealittle.Application.UnitTests.TestUtils.Constants;

namespace Takealittle.Application.UnitTests.Products.Commands.TestUtils;

public static class CreateProductCommandUtils
{
    public static CreateProductCommand CreateCommand() => new CreateProductCommand
    {
        Name = Constants.Product.Name,
        Barcode = Constants.Product.Barcode,
        Description = Constants.Product.Description,
        Price = Constants.Product.Price
    };
}