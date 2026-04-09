using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICurso : IGeneric<Curso>
    {
        Task<List<CursoGetByUserRolDto>> GetCursosByRolAndUserAsync(string user, string rol);
    }
}
