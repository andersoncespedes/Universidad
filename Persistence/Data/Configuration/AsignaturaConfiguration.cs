using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
{
    public void Configure(EntityTypeBuilder<Asignatura> builder)
    {
        builder.ToTable("asignatura");
        builder.Property(e => e.Id)
        .HasColumnName("id");
        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(e => e.Creditos)
        .HasColumnName("creditos")
        .IsRequired()
        .HasPrecision(2,8);

        builder.Property(e => e.Tipos)
        .HasColumnName("tipo")
        .IsRequired()
        .HasAnnotation("EnumDisplayFormat", "{0}")
        .HasMaxLength(15)
        .HasConversion<string>()
        .IsUnicode(false);
        ;

        builder.Property(e => e.Curso)
        .HasColumnName("curso")
        .HasColumnType("tinyint")
        .IsRequired();

        builder.Property(e => e.Cuatrimestre)
        .HasColumnName("cuatrimestre")
        .HasColumnType("tinyint")
        .IsRequired();

        builder.HasOne(e => e.Profesor)
        .WithMany(e => e.Asignaturas)
        .HasForeignKey(e => e.IdProfesorFk);
        builder.Property(e => e.IdProfesorFk);

        builder.HasOne(e => e.Grado)
        .WithMany(e => e.Asignaturas)
        .HasForeignKey(e => e.IdGradoFk);

    }
}
