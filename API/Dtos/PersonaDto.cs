using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class PersonaDto
{
    public int Id {get; set;}
    public string Nif {get; set;}
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Nombre { get; set; }
}
