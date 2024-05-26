using Takealittle.Application.Features.Products.Commands.UpdateProduct;
using Takealittle.Application.UnitTests.TestUtils.Constants;

namespace Takealittle.Application.UnitTests.Products.Commands.TestUtils;

public static class UpdateProductCommandUtils
{
    public static UpdateProductCommand UpdateCommand() => new UpdateProductCommand
    {
        Name = Constants.Product.Name,
        Barcode = Constants.Product.Barcode,
        Description = Constants.Product.Description,
        Price = Constants.Product.Price
    };
}