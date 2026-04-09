namespace Application.Dtos;
public class UsuarioGetAllDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<RolDto> Roles { get; set; }
    //public List<UsuarioRolDto> UsuariosRoles { get; set; }
        
}