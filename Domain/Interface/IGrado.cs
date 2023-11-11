using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IGrado : IGenericRepository<Grado>
{
    Task<IEnumerable<Grado>> GradosWithCountAssign();
    Task<IEnumerable<Grado>> GradosWithCountAssignWithMoreThan40();
    Task<IEnumerable<Grado>> GradosWithAssignWithCredits();
}
