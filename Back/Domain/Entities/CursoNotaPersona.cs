namespace Domain.Entities;
public class CursoNotaPersona
{
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
    public int NotaId { get; set; }
    public Nota Nota { get; set; }
}
