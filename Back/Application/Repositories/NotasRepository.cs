using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class NotasRepository: GenericRepository<Nota>, INotas
    {
        private readonly EduProgressContext _context;

        public NotasRepository(EduProgressContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<NotasStuCursoDto>> GetNotasByCursoAndUserAsync(string user, string curso)
        {

            var notas = _context.Notas
            .Include(n => n.CursoNotaPersonas)
                .ThenInclude(cnp => cnp.Usuario)
                    .ThenInclude(u => u.UsuarioRoles)
                        .ThenInclude(ur => ur.Rol)
            .Include(n => n.CursoNotaPersonas)
                .ThenInclude(cnp => cnp.Curso)
            .Include(n => n.Categoria)
            .Where(n => n.CursoNotaPersonas.Any(cnp =>
                cnp.Usuario.Username == user &&
                cnp.Usuario.UsuarioRoles.Any(ur => ur.Rol.Nombre == "Estudiante") &&
                cnp.Curso.Nombre == curso))
            .Select(x=>new NotasStuCursoDto()
            {
                Id = x.Id,
                Nota=x.Valor,
                Categoria=x.Categoria.Nombre
            })
            .ToList();

            List<string> categorias=_context.CategoriaNotas.Select(x=>x.Nombre).ToList();

            foreach (var item in categorias)
            {
                if (!notas.Any(x => x.Categoria.Equals(item))){
                    notas.Add(new NotasStuCursoDto() { Categoria=item });
                }
            }


            return (notas);
        }
    }
}
