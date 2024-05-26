using MapsterMapper;
using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;
using Takealittle.Domain.Entities;

namespace Takealittle.Application.Features.Products.Commands.CreateProductImage;

public partial class CreateProductImageCommand : IRequest<Response<int>>
{
    public int ProductId { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
}

public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, Response<int>>
{
    private readonly IProductImageRepository _productImageRepository;
    private readonly IMapper _mapper;
    
    public CreateProductImageCommandHandler(IProductImageRepository productImageRepository, IMapper mapper)
    {
        _productImageRepository = productImageRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
    {
        var productImage = _mapper.Map<ProductImage>(request);
        await _productImageRepository.AddAsync(productImage);
        return new Response<int>(productImage.Id);
    }
}