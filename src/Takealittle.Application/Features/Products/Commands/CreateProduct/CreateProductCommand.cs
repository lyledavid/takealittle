using MapsterMapper;
using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;
using Takealittle.Domain.Entities;

namespace Takealittle.Application.Features.Products.Commands.CreateProduct;

public partial class CreateProductCommand : IRequest<Response<Product>>
{
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Response<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.AddAsync(product);
        return new Response<Product>(product);
    }
}