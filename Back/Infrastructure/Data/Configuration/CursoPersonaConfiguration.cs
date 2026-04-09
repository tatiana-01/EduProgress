using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configuracion;
public class CursoPersonaConfiguration : IEntityTypeConfiguration<CursoPersona>
{
    public void Configure(EntityTypeBuilder<CursoPersona> builder)
    {
        builder.ToTable("CursoPersona").HasKey(uc => uc.Id);


        builder
            .HasOne(uc => uc.Usuario)
            .WithMany(u => u.CursoPersonas)
            .HasForeignKey(uc => uc.UsuarioId);


        builder
           .HasOne(uc => uc.Curso)
           .WithMany(u => u.CursoPersonas)
           .HasForeignKey(uc => uc.CursoId);


        builder
           .HasOne(uc => uc.Rol)
           .WithMany(u => u.CursoPersonas)
           .HasForeignKey(uc => uc.RolId);



  

    }
}