using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;
using Takealittle.Domain.Entities;

namespace Takealittle.Application.Features.Products.Queries.GetProduct;

public class GetProductQuery : IRequest<Response<Product>>
{
    public int Id { get; set; }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductQuery, Response<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Response<Product>> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(query.Id);
            if (product == null) throw new Exception($"Product Not Found.");
            return new Response<Product>(product);
        }
    }
}