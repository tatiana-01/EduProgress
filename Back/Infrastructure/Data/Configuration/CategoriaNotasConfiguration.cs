using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion;
public class CategoriaNotasConfiguration : IEntityTypeConfiguration<CategoriaNotas>
{
    public void Configure(EntityTypeBuilder<CategoriaNotas> builder)
    {
        builder.ToTable("CategoriaNotas");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Detalle)
        .HasMaxLength(255); 

        builder.HasMany(p => p.Notas)
        .WithOne(p => p.Categoria)
        .HasForeignKey(p => p.CategoriaId);
    }
}