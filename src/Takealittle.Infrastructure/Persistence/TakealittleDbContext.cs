using Microsoft.EntityFrameworkCore;
using Takealittle.Application.Common.Interfaces.Authentication;
using Takealittle.Domain.Common;
using Takealittle.Domain.Entities;

namespace Takealittle.Infrastructure.Persistence;

public class TakealittleDbContext : DbContext
{
    private readonly IAuthenticatedUserService _authenticatedUser;
    
    public TakealittleDbContext(DbContextOptions<TakealittleDbContext> options, IAuthenticatedUserService authenticatedUser) : base(options)
    {
        _authenticatedUser = authenticatedUser;
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _authenticatedUser.User;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = _authenticatedUser.User;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductImage> ProductImages { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(TakealittleDbContext).Assembly);
        builder.Seed();
        base.OnModelCreating(builder);
    }
}