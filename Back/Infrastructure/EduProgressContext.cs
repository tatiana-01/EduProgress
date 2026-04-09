using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Seeding;
using System.Reflection;

namespace Infrastructure;

public class EduProgressContext : DbContext
{
    public EduProgressContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioRol> UsuarioRoles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<CategoriaNotas> CategoriaNotas { get; set; }
    public DbSet<Comportamiento> Comportamientos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<CursoNotaPersona> CursoNotaPersonas { get; set; }
    public DbSet<CursoPersona> CursoPersonas { get; set; }
    public DbSet<Nota> Notas { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Seguimiento> Seguimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedingInicial.Seed(modelBuilder);
    }
}