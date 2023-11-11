using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
    public class GradoWithSumDto
    {
        public string NombreGrado {get; set;}
        public IEnumerable<string> TipoAsignatura {get; set;}
        public int SumaCreditos {get; set;}
    }
