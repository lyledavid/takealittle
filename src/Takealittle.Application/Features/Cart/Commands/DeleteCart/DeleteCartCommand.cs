using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Cart.Commands.DeleteCart;

public class DeleteCartCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Response<int>>
    {
        private readonly ICartRepository _cartRepository;
        public DeleteCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Response<int>> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(command.Id);
            if (cart == null) throw new Exception($"Product Not Found.");
            await _cartRepository.DeleteAsync(cart);
            return new Response<int>(cart.Id);
        }
    }
}