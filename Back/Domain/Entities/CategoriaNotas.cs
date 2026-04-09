namespace Domain.Entities;
public class CategoriaNotas : BaseEntity
{
    public string Nombre { get; set; }
    public string Detalle { get; set; }
    public ICollection<Nota> Notas { get; set; }
}
