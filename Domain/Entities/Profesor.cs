using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Profesor : BaseEntity
{
    public int IdProfesorFk {get; set;}
    public Persona ProfesorP {get; set;}
    public int IdDepartamento {get; set;}
    public Departamento Departamento {get; set;}
    public ICollection<Asignatura> Asignaturas {get; set;}

}
