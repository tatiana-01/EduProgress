using Application.Dtos;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public class SeguimientoRepository : GenericRepository<Seguimiento>, ISeguimiento
{
    private readonly EduProgressContext _context;

    public SeguimientoRepository(EduProgressContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> AddComByUser(string user, int comId, string come)
    {
        var userId=_context.Usuarios.Where(x=>x.Username==user).FirstOrDefault();
        var seg = new Seguimiento()
        {
            UsuarioId = userId.Id,
            Comentario = come,
            ComportamientoId = comId
        };
        _context.Seguimientos.Add(seg);
        return await _context.SaveChangesAsync();
    }
}