using Microsoft.EntityFrameworkCore;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Domain.Entities;

namespace Takealittle.Infrastructure.Persistence.Repositories;

public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
{
    private readonly DbSet<ProductImage> _productImages;

    public ProductImageRepository(TakealittleDbContext dbContext) : base(dbContext)
    {
        _productImages = dbContext.Set<ProductImage>();
    }
}