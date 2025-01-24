using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface INotas : IGeneric<Nota>
    {
        Task<List<NotasStuCursoDto>> GetNotasByCursoAndUserAsync(string user, string curso);
    }
}
