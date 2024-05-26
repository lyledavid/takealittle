using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Takealittle.Application.Common.Interfaces;

namespace Takealittle.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TakealittleDbContext _dbContext;

    public GenericRepository(TakealittleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }
    
    public IQueryable<T> GetQueryable()
    {
        var query = _dbContext.Set<T>().AsQueryable();

        return query;
    }
    
    public async Task<T?> LoadAsync(Expression<Func<T, bool>> expression)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        return await query.Where(expression)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
    }
    
    public async Task<List<T>> LoadAllAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbContext.Set<T>().Where(expression).ToListAsync().ConfigureAwait(false);
    }
}