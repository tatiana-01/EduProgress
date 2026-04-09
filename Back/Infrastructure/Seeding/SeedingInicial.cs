using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Seeding;
public class SeedingInicial
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var AdministradorRol = new Rol()
        {
            Id = 1,
            Nombre = "Administrador"
        };
        var ProfesorRol = new Rol()
        {
            Id = 2,
            Nombre = "Profesor"
        };
        var EstudianteRol = new Rol()
        {
            Id = 3,
            Nombre = "Estudiante"
        };
        var PersonaRol = new Rol()
        {
            Id = 4,
            Nombre = "Persona"
        };
        var Corte1 = new CategoriaNotas()
        {
            Id = 1,
            Nombre = "Corte 1",
            Detalle="Corresponde al primer periodo del año del curso."
        };
        var Corte2 = new CategoriaNotas()
        {
            Id = 2,
            Nombre = "Corte 2",
            Detalle = "Corresponde al segundo periodo del año del curso."
        };
        var Corte3 = new CategoriaNotas()
        {
            Id = 3,
            Nombre = "Corte 3",
            Detalle = "Corresponde al tercer periodo del año del curso."
        };
        var NotaFinal = new CategoriaNotas()
        {
            Id = 4,
            Nombre = "Nota Final",
            Detalle = "Corresponde al promedio de todo el año."
        };
        /*       var Administrador = new Usuario()
               {
                   Id=1,
                   Username="Admin",
                   Email="admin@gmail.com",
               };
               var _passwordHasher = new PasswordHasher<Usuario>();
               Administrador.Password = _passwordHasher.HashPassword(Administrador, "123456");
               var AdminUsuarioRol = new UsuarioRol()
               {
                   RolId = 1,
                   UsuarioId = 1
               };*/
        // modelBuilder.Entity<Usuario>().HasData(Administrador);
        modelBuilder.Entity<Rol>().HasData(AdministradorRol, ProfesorRol, EstudianteRol,PersonaRol);
        modelBuilder.Entity<CategoriaNotas>().HasData(Corte1,Corte2,Corte3,NotaFinal);
        // modelBuilder.Entity<UsuarioRol>().HasData(AdminUsuarioRol);
    }
}