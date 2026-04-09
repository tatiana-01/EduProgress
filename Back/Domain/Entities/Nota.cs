namespace Domain.Entities;
public class Nota : BaseEntity
{
    public decimal Valor { get; set; }
    public int CategoriaId { get; set; }
    public CategoriaNotas Categoria { get; set; }
    public ICollection<CursoNotaPersona> CursoNotaPersonas { get; set; }
}
