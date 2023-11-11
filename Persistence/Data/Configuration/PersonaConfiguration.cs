using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(e => e.Id)
        .HasColumnName("id");

        builder.Property(e => e.Nif)
        .IsRequired()
        .HasColumnName("nif")
        .HasMaxLength(9);

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasColumnName("nombre")
        .HasMaxLength(25);

        builder.Property(e => e.Apellido1)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnName("apellido1");

        builder.Property(e => e.Apellido2)
        .HasColumnName("apellido2")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Ciudad)
        .IsRequired()
        .HasMaxLength(25)
        .HasColumnName("ciudad");

        builder.Property(e => e.Direccion)
        .IsRequired()
        .HasColumnName("direccion")
        .HasMaxLength(50);

        builder.Property(e => e.Telefono)
        .HasMaxLength(9)
        .HasColumnName("telefono");

        builder.HasIndex(e => e.Telefono).IsUnique();

        builder.HasIndex(e => e.Nif).IsUnique();
        builder.Property(e => e.FechaNacimiento)
        .IsRequired()
        .HasColumnName("fecha_nacimiento")
        .HasColumnType("date");

        builder.Property(e => e.Sexo)
        .HasColumnName("sexo")
        .IsRequired()
        .HasAnnotation("EnumDisplayFormat", "{0}")
        .HasMaxLength(15)
        .HasConversion<string>()
        .IsUnicode(false);

        builder.Property(e => e.Tipo)
        .HasAnnotation("EnumDisplayFormat", "{0}")
        .IsUnicode(false)
        .HasMaxLength(15)
        .IsRequired()
        .HasConversion<string>()
        .HasColumnName("tipo");

        builder.HasMany(e => e.Asignaturas)
        .WithMany(e => e.Personas)
        .UsingEntity<AlumnoSeMatriculaAsignatura>(
            j => j.HasOne(e => e.Asignatura)
            .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
            .HasForeignKey(e => e.IdAsignaturaFk),

            j => j.HasOne(e => e.Alumno)
            .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
            .HasForeignKey(e => e.IdAlumnoFk),
            j => {
                j.HasKey(e => new {e.IdAlumnoFk, e.IdAsignaturaFk, e.IdCursoEscolarFk});
            }
        );
        builder.HasMany(e => e.CursoEscolares)
        .WithMany(e => e.Personas)
        .UsingEntity<AlumnoSeMatriculaAsignatura>(
            j => j.HasOne(e => e.CursoEscolar)
            .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
            .HasForeignKey(e => e.IdCursoEscolarFk),

            j => j.HasOne(e => e.Alumno)
            .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
            .HasForeignKey(e => e.IdAlumnoFk),
            j => {
            }
        );

    }
}
