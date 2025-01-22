using Domain.Entities;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Application.Dtos;

namespace Application.Repositories;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly EduProgressContext _context;

    public PersonaRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<CursoDto>> GetStudentsByCourse(string course)
    {

        var result = _context.Personas
            .Include(c => c.Usuario)
                .ThenInclude(cp => cp.CursoPersonas)
                    .ThenInclude(u => u.Rol)
            .Where(u => u.Usuario.CursoPersonas.Any(cp => cp.Curso.Nombre == course &&
                                                   cp.Usuario.UsuarioRoles.Any(ur => ur.Rol.Nombre == "Estudiante")))
            .Select(x => new CursoDto()
            {
                Nombre = x.Nombre +" " + x.Apellido,
                Detalle = x.Usuario.Username + " - " + x.Usuario.Email
            })
            .ToList();

        return (result);
    }


}