
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly APIContext _context;
    public DepartamentoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Departamento>> GetWithProfWhoDoesHaveAsign(){
        return await _context.Set<Departamento>()
            .Include(e => e.Profesores)
            .Where(e => e.Profesores.SelectMany(e => e.Asignaturas)
            .Where(e => e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)").Any())
            .ToListAsync();
    }
    public async Task<IEnumerable<Departamento>> GetWithAsignWithNoCourse(){
        return await _context.Set<Departamento>()
            .Include(e => e.Profesores)
            .ThenInclude(e => e.Asignaturas.Where(e => e.Personas.Count() == 0))
            .ThenInclude(e => e.Personas.Where(e => e.Tipo == Tipo.alumno))
            .ToListAsync();
    }
    public async Task<IEnumerable<Departamento>> GetCountWithProf(){
        return await _context.Set<Departamento>()
            .Include(e => e.Profesores)
            .Where(e => e.Profesores.Count() > 0)
            .OrderByDescending(e => e.Profesores.Count())
            .ToListAsync();
    }
    public async Task<IEnumerable<Departamento>> GetCountWithProfAll(){
        return await _context.Set<Departamento>()
            .Include(e => e.Profesores)

            .OrderByDescending(e => e.Profesores.Count())
            .ToListAsync();
    }
    public async Task<IEnumerable<Departamento>> GetDepWithNoProf(){
        return await _context.Set<Departamento>()
            .Include(e => e.Profesores)
            .Where(e => e.Profesores.Count() == 0)
            .ToListAsync();
    }
    public async Task<IEnumerable<Departamento>> GetDepWithNoAssign(){
        return await _context.Set<Departamento>()
            .Include(e => e.Profesores)
            .Where(e => e.Profesores.Select(e => e.Asignaturas.Count()).Sum() == 0)
            .ToListAsync();
    }
}
