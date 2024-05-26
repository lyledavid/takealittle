using System.Linq.Expressions;

namespace Takealittle.Application.Common.Interfaces;


public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IQueryable<T> GetQueryable();
    Task<T?> LoadAsync(Expression<Func<T, bool>> expression);
    Task<List<T>> LoadAllAsync(Expression<Func<T, bool>> expression);
}