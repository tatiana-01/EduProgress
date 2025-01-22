using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;
public interface IPersona:IGeneric<Persona>
    {
    Task<List<CursoDto>> GetStudentsByCourse(string course);
}
