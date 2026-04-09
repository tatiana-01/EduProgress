using Domain.Entities;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Repositories;
public class GenericRepository<T> : IGeneric<T> where T : BaseEntity
{
    private readonly EduProgressContext _context;

    public GenericRepository(EduProgressContext context)
    {
        _context = context;
    }

    public async Task<int> Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        return await _context.SaveChangesAsync();
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<int> Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync();
    }
}