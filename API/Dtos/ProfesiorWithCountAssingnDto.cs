using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class ProfesiorWithCountAssingnDto
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public string Apellido1 {get; set;}
    public string Apellido2 {get; set;}
    public int Asignaturas {get; set;}
}
