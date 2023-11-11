using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IAsignatura : IGenericRepository<Asignatura>
{
    Task<IEnumerable<Asignatura>> GetFirstCuatrimestre();
    Task<IEnumerable<Persona>> GetByAlumnsGirlsThatMatIng();
    Task<IEnumerable<Asignatura>> GetByGrado();
    
}
