using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface ICursoEscolar : IGenericRepository<CursoEscolar>
{
    Task<IEnumerable<Persona>> GetStudentsDate();
    Task<IEnumerable<CursoEscolar>> GetStudentsDateAndCount();
}
