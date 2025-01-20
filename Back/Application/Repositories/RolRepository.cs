using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly EduProgressContext _context;

    public RolRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Rol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Roles as IQueryable<Rol>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Usuarios)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Set<Rol>()
        .Include(p => p.Usuarios)
        .FirstOrDefaultAsync(p => p.Id == id);
    }


}