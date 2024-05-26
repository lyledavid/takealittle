using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Cart.Commands.AddCartItem;

public partial class AddCartItemCommand : IRequest<Response<int>>
{
    public int ProductId { get; set; }
}

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, Response<int>>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;

    public AddCartItemCommandHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<Response<int>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetActiveCartAsync(); 
        if (cart == null) throw new Exception($"No Active Cart Not Found.");
        
        var cartItem = new Domain.Entities.CartItem
        {
            CartId = cart.Id,
            ProductId = request.ProductId,
        };
        await _cartItemRepository.AddAsync(cartItem);
        return new Response<int>(cart.Id);
    }
}