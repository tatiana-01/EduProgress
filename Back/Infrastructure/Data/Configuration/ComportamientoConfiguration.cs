using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion;
public class ComportamientoConfiguration : IEntityTypeConfiguration<Comportamiento>
{
    public void Configure(EntityTypeBuilder<Comportamiento> builder)
    {
        builder.ToTable("Comportamiento");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Valor)
        .HasColumnType("decimal(18, 2)")
        .IsRequired();

        builder.Property(p => p.Descripcion)
        .HasMaxLength(255)
        .IsRequired();

   

    }
}