namespace Domain.Entities;
public class ComportamientoPersona 
{
    public int ComportamientoId { get; set; }
    public Comportamiento Comportamiento { get; set; }
    public int CursoPersonaId { get; set; }
    public CursoPersona CursoPersona { get; set; }
}
