using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IProfesor : IGenericRepository<Profesor>
{
    Task<IEnumerable<Profesor>> GetWithDept();
    Task<IEnumerable<Profesor>> GetAllWithDept();
    Task<(IEnumerable<Profesor> profesors, IEnumerable<Departamento> departamentos)> GetWithNoDept();
    Task<IEnumerable<Persona>> GetWithNoAsignatures();
}
