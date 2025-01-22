namespace Domain.Entities;
public class Comportamiento : BaseEntity
{
    public decimal Valor { get; set; }
    public string Descripcion { get; set; }
    public int CursoPersonaId { get; set; }
    public string Tema { get; set; }
    public ICollection<ComportamientoPersona> ComportamientoPersonas { get; set; }

}
