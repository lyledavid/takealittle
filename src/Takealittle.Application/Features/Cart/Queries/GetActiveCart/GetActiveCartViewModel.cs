using Takealittle.Application.Features.Products.Queries.GetAllProducts;

namespace Takealittle.Application.Features.Cart.Queries.GetActiveCart;

public class GetActiveCartViewModel
{
    public GetActiveCartViewModel(List<GetAllProductsViewModel> items)
    {
        Items = items;
    }

    public int Id { get; set; }
    public DateTime Created { get; set; }
    public List<GetAllProductsViewModel> Items { get; set; }
}