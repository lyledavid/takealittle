using MediatR;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Application.Wrappers;
using Takealittle.Domain.Entities;

namespace Takealittle.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Response<Product>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<Product>>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Response<Product>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id);

            if (product == null)
            {
                throw new Exception($"Product Not Found.");
            }
            else
            {
                product.Name = command.Name;
                product.Price = command.Price;
                product.Description = command.Description;
                await _productRepository.UpdateAsync(product);
                return new Response<Product>(product);
            }
        }
    }
}