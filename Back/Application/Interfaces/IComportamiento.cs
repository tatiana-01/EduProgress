using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IComportamiento : IGeneric<Comportamiento>
    {
        Task<List<ComByUserCourseDto>> GetComsByCursoAndUserAsync(string user, string curso);
    }
}
