using MapsterMapper;
using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<PagedResponse<IEnumerable<GetAllProductsViewModel>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<IEnumerable<GetAllProductsViewModel>>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetAllProductsViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var validFilter = _mapper.Map<RequestParameter>(request);
        var product = await _productRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
        var productViewModel = _mapper.Map<IEnumerable<GetAllProductsViewModel>>(product);
        return new PagedResponse<IEnumerable<GetAllProductsViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);           
    }
}