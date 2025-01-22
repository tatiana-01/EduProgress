namespace Application.Dtos;
public class RolGetAllDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<UsuarioDto> Usuarios { get; set; }
    //public List<UsuarioRolDto> UsuariosRoles { get; set; }
        
}