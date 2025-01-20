using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly EduProgressContext _context;

    public PersonaRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }

    

}