using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class AsignaturaByStudentDto
{
    public ICollection<AsignaturaDto> Asignaturas {get; set;}
    public ICollection<CursoEscolarDto> CursoEscolares {get; set;}
}
