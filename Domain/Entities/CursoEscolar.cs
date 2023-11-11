
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class CursoEscolar : BaseEntity
{
    public short AnyoInicio { get; set; }
    public short AnyoFin { get; set; }
    public ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; }
    public ICollection<Persona> Personas { get; set; }
    public ICollection<Asignatura> Asignaturas { get; set; }
}
