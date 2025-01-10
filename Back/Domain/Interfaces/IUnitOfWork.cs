namespace Domain.Interfaces;
public interface IUnitOfWork
    {
        IRol Roles{get;}
        IUsuario Usuarios{get;}
        IUsuarioRol UsuarioRoles {get;}
        Task<int> SaveAsync();
    }
