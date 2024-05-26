using MediatR;
using Takealittle.Application.Common.Interfaces.Authentication;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Cart.Commands.CreateCart;

public partial class CreateCartCommand : IRequest<Response<int>>
{
}

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Response<int>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IAuthenticatedUserService _authenticatedUserService;

    public CreateCartCommandHandler(ICartRepository cartRepository, IAuthenticatedUserService authenticatedUserService)
    {
        _cartRepository = cartRepository;
        _authenticatedUserService = authenticatedUserService;
    }

    public async Task<Response<int>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = new Domain.Entities.Cart
        {
            User = _authenticatedUserService.User!,
            Created = DateTime.Now,
            IsProcessed = false
        };

        await _cartRepository.AddAsync(cart);
        return new Response<int>(cart.Id);
    }
}