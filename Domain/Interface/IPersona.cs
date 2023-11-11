using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IPersona : IGenericRepository<Persona>
{
    IEnumerable<Persona> AllSort();
    IEnumerable<Persona> AllButNotNull();
    IEnumerable<Persona> GetBeforeTwoThounsend();
    IEnumerable<Persona> AllButNotNullWithK();
    Task<IEnumerable<Persona>> GetByNif();
    Task<int> GetCountGirlStudents();
    Task<int> GetCountMillen();
    Task<Persona> GetYoungest();
}
