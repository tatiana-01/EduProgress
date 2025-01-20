using System.ComponentModel.DataAnnotations;

namespace EduProgressApi.Dtos;
public class RegisterDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Apellido { get; set; }

    public DateTime FecNacimiento { get; set; }
}