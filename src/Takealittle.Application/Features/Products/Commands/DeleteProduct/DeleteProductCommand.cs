using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;

namespace Takealittle.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<int>>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Response<int>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id);
            if (product == null) throw new Exception($"Product Not Found.");
            await _productRepository.DeleteAsync(product);
            return new Response<int>(product.Id);
        }
    }
}