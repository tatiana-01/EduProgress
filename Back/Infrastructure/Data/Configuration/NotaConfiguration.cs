using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion;
public class NotaConfiguration : IEntityTypeConfiguration<Nota>
{
    public void Configure(EntityTypeBuilder<Nota> builder)
    {
        builder.ToTable("Nota");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Valor)
       .HasColumnType("decimal(18, 2)")
       .IsRequired();


    }
}