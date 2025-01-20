namespace Domain.Entities;
public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

}
