using Takealittle.Domain.Entities;

namespace Takealittle.Application.Common.Interfaces.Persistence;

public interface ICartRepository : IGenericRepository<Cart>
{
    Task<Cart?> GetActiveCartAsync();
}