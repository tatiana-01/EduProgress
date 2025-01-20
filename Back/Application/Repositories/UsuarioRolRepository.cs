using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Repositories;
public class UsuarioRolRepository :  IUsuarioRol
{
    private readonly EduProgressContext _context;

    public UsuarioRolRepository(EduProgressContext context) 
    {
        _context = context;
    }

    public async Task<int> Add(UsuarioRol entity)
    {
        _context.Set<UsuarioRol>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> AddRange(IEnumerable<UsuarioRol> entities)
    {
        _context.Set<UsuarioRol>().AddRange(entities);
        return await _context.SaveChangesAsync();
    }

    public  async Task<(int totalRegistros, IEnumerable<UsuarioRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.UsuarioRoles as IQueryable<UsuarioRol>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual async Task<UsuarioRol> GetByIdAsync(int idUsuario, int idRol)
    {
        return await _context.Set<UsuarioRol>().FirstOrDefaultAsync(x => x.RolId == idRol && x.UsuarioId == idUsuario);
    }

    public async Task<int> Remove(UsuarioRol entity)
    {
        _context.Set<UsuarioRol>().Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> RemoveRange(IEnumerable<UsuarioRol> entities)
    {
        _context.Set<UsuarioRol>().RemoveRange(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(UsuarioRol entity)
    {
        _context.Set<UsuarioRol>().Update(entity);
        return await _context.SaveChangesAsync();
    }
    public virtual IEnumerable<UsuarioRol> Find(Expression<Func<UsuarioRol, bool>> expression)
    {
        return _context.Set<UsuarioRol>().Where(expression);
    }

}