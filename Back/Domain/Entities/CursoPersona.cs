namespace Domain.Entities;
public class CursoPersona : BaseEntity
{
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
    public int RolId { get; set; }
    public Rol Rol { get; set; }
    public ICollection<ComportamientoPersona> ComportamientoPersonas { get; set; }
    public ICollection<Seguimiento> Seguimientos { get; set; }



}
