using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class AlumnoSeMatriculaAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoSeMatriculaAsignatura>
{
    public void Configure(EntityTypeBuilder<AlumnoSeMatriculaAsignatura> builder)
    {
        builder.ToTable("alumno_se_matricula_asignatura");
        builder.Property(e => e.IdAlumnoFk)
        .HasColumnName("id_alumno");

        builder.Property(e => e.IdAsignaturaFk)
        .HasColumnName("id_asignatura");

        builder.Property(e => e.IdCursoEscolarFk)
        .HasColumnName("id_curso_escolar");

    }
}
