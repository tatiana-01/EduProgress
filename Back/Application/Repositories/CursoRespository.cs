using Application.Dtos;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public class CursoRepository : GenericRepository<Curso>, ICurso
{
    private readonly EduProgressContext _context;

    public CursoRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<CursoGetByUserRolDto>> GetCursosByRolAndUserAsync(string user, string rol)
    {

        var result = _context.Cursos
            .Include(c => c.CursoPersonas)
                .ThenInclude(cp => cp.Usuario)
                    .ThenInclude(u => u.UsuarioRoles)
                        .ThenInclude(ur => ur.Rol)
            .Where(u => u.CursoPersonas.Any(cp => cp.Usuario.Username == user &&
                                                   cp.Usuario.UsuarioRoles.Any(ur => ur.Rol.Nombre == rol)))
            .Select(x => new CursoGetByUserRolDto()
            {
                Nombre = x.Nombre,
                Detalle = x.Detalle,
                NombreProfesor = String.Join(" ", _context.Personas
                        .Include(x => x.Usuario)
                        .ThenInclude(u => u.CursoPersonas)
                        .ThenInclude(cp => cp.Rol)
                        .Where(p => p.Usuario.CursoPersonas.Any(z => z.Rol.Nombre == "Profesor" && z.CursoId == x.Id))
                        .Select(x => x.Nombre + " " + x.Apellido))
            })
            .ToList();



        return (result);
    }
}