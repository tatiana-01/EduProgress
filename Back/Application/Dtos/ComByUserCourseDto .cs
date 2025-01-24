namespace Application.Dtos;
public class ComByUserCourseDto:NotasStuCursoDto
{
    public string Profesora { get; set; }
    public string Tema { get; set; }
    public List<Segs> Seguimientos { get; set; }


}

public class Segs
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
} 