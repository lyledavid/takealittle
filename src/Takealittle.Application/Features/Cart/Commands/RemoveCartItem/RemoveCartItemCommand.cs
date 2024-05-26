using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Cart.Commands.RemoveCartItem;

public class RemoveCartItemCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, Response<int>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        
        public RemoveCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Response<int>> Handle(RemoveCartItemCommand command, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(command.Id);
            if (cartItem == null) throw new Exception($"Cart Item Not Found.");
            await _cartItemRepository.DeleteAsync(cartItem);
            return new Response<int>(cartItem.Id);
        }
    }
}