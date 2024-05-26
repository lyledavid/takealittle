using Takealittle.Domain.Entities;

namespace Takealittle.Application.Common.Interfaces.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> IsUniqueBarcodeAsync(string barcode);
}