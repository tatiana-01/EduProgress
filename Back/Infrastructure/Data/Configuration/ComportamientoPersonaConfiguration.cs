using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configuracion;
public class ComportamientoPersonaConfiguration : IEntityTypeConfiguration<ComportamientoPersona>
{
    public void Configure(EntityTypeBuilder<ComportamientoPersona> builder)
    {
        builder.ToTable("ComportamientoPersona").HasKey(uc => new { uc.ComportamientoId, uc.CursoPersonaId });




        builder
           .HasOne(uc => uc.Comportamiento)
           .WithMany(u => u.ComportamientoPersonas)
           .HasForeignKey(uc => uc.ComportamientoId);


        builder
           .HasOne(uc => uc.CursoPersona)
           .WithMany(u => u.ComportamientoPersonas)
           .HasForeignKey(uc => uc.CursoPersonaId);

    }
}