using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configuracion;
public class CursoNotaPersonaConfiguration : IEntityTypeConfiguration<CursoNotaPersona>
{
    public void Configure(EntityTypeBuilder<CursoNotaPersona> builder)
    {
        builder.ToTable("CursoNotaPersona").HasKey(uc => new { uc.UsuarioId, uc.CursoId, uc.NotaId });


        builder
            .HasOne(uc => uc.Usuario)
            .WithMany(u => u.cursoNotaPersonas)
            .HasForeignKey(uc => uc.UsuarioId);


        builder
           .HasOne(uc => uc.Curso)
           .WithMany(u => u.CursoNotaPersonas)
           .HasForeignKey(uc => uc.CursoId);


        builder
           .HasOne(uc => uc.Nota)
           .WithMany(u => u.CursoNotaPersonas)
           .HasForeignKey(uc => uc.NotaId);

    }
}