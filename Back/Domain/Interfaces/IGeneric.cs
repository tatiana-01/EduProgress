using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces;
public interface IGeneric<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    Task<int> Add(T entity);
    Task<int> Remove(T entity);
    Task<int> AddRange(IEnumerable<T> entities);
    Task<int> RemoveRange(IEnumerable<T> entities);
    Task<int> Update(T entity);
}


