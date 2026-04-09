namespace Domain.Entities;
public class Seguimiento : BaseEntity
{
    public string Comentario { get; set; }
    public int UsuarioId { get; set; }
    public int ComportamientoId { get; set; }
    public Comportamiento Comportamiento { get; set; }
    public Usuario Usuario { get; set; }
}
