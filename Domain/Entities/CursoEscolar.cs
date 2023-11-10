
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class CursoEscolar : BaseEntity
{
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yy}", ApplyFormatInEditMode = true)]
    public DateOnly AnyoInicio { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yy}", ApplyFormatInEditMode = true)]
    public DateOnly AnyoFin { get; set; }
    public ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; }
    public ICollection<Persona> Personas { get; set; }
    public ICollection<Asignatura> Asignaturas { get; set; }
}
