using MapsterMapper;
using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Features.Products.Queries.GetAllProducts;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Cart.Queries.GetActiveCart;

public class GetActiveCartQuery : IRequest<Response<GetActiveCartViewModel>>
{
    public class GetActiveCartQueryHandler : IRequestHandler<GetActiveCartQuery, Response<GetActiveCartViewModel>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public GetActiveCartQueryHandler(ICartRepository cartRepository, IProductRepository productRepository, ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        
        public async Task<Response<GetActiveCartViewModel>> Handle(GetActiveCartQuery query, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetActiveCartAsync();
            if (cart == null) throw new Exception($"Cart Not Found.");

            var productIds = (await _cartItemRepository.LoadAllAsync(x => x.CartId == cart.Id).ConfigureAwait(false)).Select(x => x.ProductId);
            var products = await _productRepository.LoadAllAsync(x => productIds.Contains(x.Id)).ConfigureAwait(false);
            var items = _mapper.Map<List<GetAllProductsViewModel>>(products);
            var response = new GetActiveCartViewModel(items)
            {
                Id = cart.Id,
                Created = cart.Created
            };
            return new Response<GetActiveCartViewModel>(response);
        }
    }
}