using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Infrastructure.Data.Configuracion;
public class SeguimientoConfiguration : IEntityTypeConfiguration<Seguimiento>
{
    public void Configure(EntityTypeBuilder<Seguimiento> builder)
    {
        builder.ToTable("Seguimiento");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Comentario)
            .HasMaxLength(255)
        .IsRequired();



    }
}