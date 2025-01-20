using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Infrastructure.Data.Configuracion;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nombre)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Apellido)
        .HasMaxLength(255)
       .IsRequired();

        builder.Property(p => p.FechaNacimiento);

        builder.HasOne(x => x.Usuario)
            .WithOne(x => x.Persona)
            .HasForeignKey<Persona>(e => e.UsuarioId);

    }
}