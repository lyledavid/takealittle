using Microsoft.EntityFrameworkCore;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Domain.Entities;

namespace Takealittle.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly DbSet<Product> _products;

    public ProductRepository(TakealittleDbContext dbContext) : base(dbContext)
    {
        _products = dbContext.Set<Product>();
    }

    public Task<bool> IsUniqueBarcodeAsync(string barcode)
    {
        return _products
            .AllAsync(p => p.Barcode != barcode);
    }
}