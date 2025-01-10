using Domain.Entities;
using EduProgressApi.Dtos;

namespace EduProgressApi.Services;
public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    //Task<string> RegisterAsync(RegisterDto registerDto, int opcionPersona, int personaId);
    Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
    Task<string> AddRolAsync(AddRolDto model);
    Task<Usuario> EditUserAsync(Usuario model);
    Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken);
}