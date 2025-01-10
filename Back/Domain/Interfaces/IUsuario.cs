using Domain.Entities;

namespace Domain.Interfaces;
public interface IUsuario:IGeneric<Usuario>
    {
        Task<Usuario> GetByUsernameAsync(string username);
        Task<Usuario> GetByRefreshTokenAsync(string username);
    }
