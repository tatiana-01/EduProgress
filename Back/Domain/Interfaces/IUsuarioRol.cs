using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces;
public interface IUsuarioRol
{
    Task<UsuarioRol> GetByIdAsync(int idUsuario, int idRol);
    //Task<IEnumerable<UsuarioRol>> GetAllAsync();
    IEnumerable<UsuarioRol> Find(Expression<Func<UsuarioRol, bool>> expression);
    Task<(int totalRegistros, IEnumerable<UsuarioRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    Task<int> Add(UsuarioRol entity);
    Task<int> AddRange(IEnumerable<UsuarioRol> entities);
    Task<int> Remove(UsuarioRol entity);
    Task<int> RemoveRange(IEnumerable<UsuarioRol> entities);
    Task<int> Update(UsuarioRol entity);
}
