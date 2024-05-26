using Microsoft.EntityFrameworkCore;
using Takealittle.Application.Common.Interfaces.Authentication;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Domain.Entities;

namespace Takealittle.Infrastructure.Persistence.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    private readonly DbSet<Cart> _carts;
    private readonly IAuthenticatedUserService _authenticatedUserService;

    public CartRepository(TakealittleDbContext dbContext, IAuthenticatedUserService authenticatedUserService) : base(dbContext)
    {
        _carts = dbContext.Set<Cart>();
        _authenticatedUserService = authenticatedUserService;
    }
    
    public Task<Cart?> GetActiveCartAsync()
    {
        return _carts
            .FirstOrDefaultAsync(c => c.User == _authenticatedUserService.User && !c.IsProcessed);
    }
}