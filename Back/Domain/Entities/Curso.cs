namespace Domain.Entities;
public class Curso : BaseEntity
{
    public string Nombre { get; set; }
    public string Detalle { get; set; }
    public ICollection<CursoNotaPersona> CursoNotaPersonas { get; set; }
    public ICollection<CursoPersona> CursoPersonas { get; set; }
    public ICollection<ComportamientoPersona> ComportamientoPersonas { get; set; }
}
