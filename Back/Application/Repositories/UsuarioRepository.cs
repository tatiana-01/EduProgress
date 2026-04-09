using Domain.Entities;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    private readonly EduProgressContext _context;

    public UsuarioRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }
      public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Usuarios
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }

    public override async Task<(int totalRegistros, IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Usuarios as IQueryable<Usuario>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Username.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Roles)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Set<Usuario>()
        .Include(p => p.Roles)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}