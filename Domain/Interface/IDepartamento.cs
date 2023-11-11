using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IDepartamento : IGenericRepository<Departamento>
{
    Task<IEnumerable<Departamento>> GetWithProfWhoDoesHaveAsign();
    Task<IEnumerable<Departamento>> GetWithAsignWithNoCourse();
    Task<IEnumerable<Departamento>> GetCountWithProf();
    Task<IEnumerable<Departamento>> GetCountWithProfAll();
    Task<IEnumerable<Departamento>> GetDepWithNoProf();
    Task<IEnumerable<Departamento>> GetDepWithNoAssign();
}
