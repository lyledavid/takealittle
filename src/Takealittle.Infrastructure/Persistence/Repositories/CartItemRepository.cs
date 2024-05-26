using Microsoft.EntityFrameworkCore;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Domain.Entities;

namespace Takealittle.Infrastructure.Persistence.Repositories;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    private readonly DbSet<CartItem> _cartItems;

    public CartItemRepository(TakealittleDbContext dbContext) : base(dbContext)
    {
        _cartItems = dbContext.Set<CartItem>();
    }
}