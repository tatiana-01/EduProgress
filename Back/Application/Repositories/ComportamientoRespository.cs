using Application.Dtos;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public class ComportamientoRepository : GenericRepository<Comportamiento>, IComportamiento
{
    private readonly EduProgressContext _context;

    public ComportamientoRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ComByUserCourseDto>> GetComsByCursoAndUserAsync(string user, string curso)
    {

        var comportamientos = _context.Comportamientos
             .Include(c => c.ComportamientoPersonas)
            .ThenInclude(cp => cp.CursoPersona)
                .ThenInclude(cursoPersona => cursoPersona.Usuario)
        .Include(c => c.ComportamientoPersonas)
            .ThenInclude(cp => cp.CursoPersona)
                .ThenInclude(cursoPersona => cursoPersona.Curso)
        .Include(c => c.ComportamientoPersonas)
            .ThenInclude(cp => cp.CursoPersona).ThenInclude(ns => ns.Rol)
        .Include(com => com.Seguimientos).ThenInclude(s => s.Usuario).ThenInclude(us => us.Persona)
        .Where(c => c.ComportamientoPersonas.Any(cp =>
            cp.CursoPersona.Usuario.Username == user &&
            cp.CursoPersona.Curso.Nombre == curso &&
            cp.CursoPersona.Rol.Nombre == "Estudiante")
        )
        .Select(com => new ComByUserCourseDto
        {
            Id = com.Id,
            Categoria = com.Descripcion,
            Tema = com.Tema,
            Nota = com.Valor,
            Seguimientos = com.Seguimientos.Select(se => new Segs() { Nombre = se.Usuario.Persona.Nombre + " " + se.Usuario.Persona.Apellido, Descripcion = se.Comentario }).ToList(),
            Profesora = _context.Personas.Include(p => p.Usuario).ThenInclude(u => u.CursoPersonas).ThenInclude(cp => cp.Curso).Include(p => p.Usuario).ThenInclude(x => x.UsuarioRoles).ThenInclude(ur => ur.Rol).Where(per => per.Usuario.CursoPersonas.Any(x => x.Curso.Nombre == curso) && per.Usuario.UsuarioRoles.Any(x => x.Rol.Nombre == "Profesor")).Select(persona => persona.Nombre + " " + persona.Apellido).FirstOrDefault()!

        })
            .ToList();
        return comportamientos;
    }
   
}