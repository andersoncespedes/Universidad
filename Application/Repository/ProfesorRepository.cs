
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
{
    private readonly APIContext _context;
    public ProfesorRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Profesor>> GetWithDept()
    {
        return await _context.Set<Profesor>()
        .Include(e => e.Departamento)
        .Include(e => e.ProfesorP)
        .Where(e => e.Departamento != null)
        .OrderByDescending(e => e.ProfesorP.Nombre)
        .ThenBy(e => e.ProfesorP.Apellido1)
        .ThenBy(e => e.ProfesorP.Apellido2)
        .ToListAsync();
    }
    public async Task<IEnumerable<Profesor>> GetAllWithDept()
    {
        return await _context.Set<Profesor>()
            .Include(e => e.Departamento)
            .Include(e => e.ProfesorP)
            .OrderByDescending(e => e.ProfesorP.Nombre)
            .ThenBy(e => e.ProfesorP.Apellido1)
            .ThenBy(e => e.ProfesorP.Apellido2)
            .ToListAsync();
    }
    public async Task<(IEnumerable<Profesor> profesors, IEnumerable<Departamento> departamentos)> GetWithNoDept()
    {
        var profesors = await _context.Set<Profesor>()
        .Include(e => e.Departamento)
        .Include(e => e.ProfesorP)
        .Where(e => e.Departamento == null)
        .ToListAsync();
        var departamentos = await _context.Set<Departamento>()
            .Include(e => e.Profesores)
            .Where(e => e.Profesores.Count == 0)
            .ToListAsync();
        return (profesors, departamentos);
    }
    public async Task<IEnumerable<Persona>> GetWithNoAsignatures()
    {
        return await _context.Set<Profesor>()
            .Where(e => e.Asignaturas.Count() == 0)
            .Select(e => e.ProfesorP)
            .ToListAsync();
    }
    public async Task<IEnumerable<Profesor>> GetWithAsignaturesCount()
    {
        return await _context.Set<Profesor>()
            .Include(e => e.Asignaturas)
            .Include(e => e.ProfesorP)
            .OrderByDescending(e => e.Asignaturas.Count())
            .ToListAsync();
    }
    public async Task<IEnumerable<Profesor>> GetProfWithoutDeps()
    {
        return await _context.Set<Profesor>()
            .Include(e => e.Departamento)
            .Include(e => e.ProfesorP)
            .Where(e => e.Departamento == null)
            .ToListAsync();
    }
    public async Task<IEnumerable<Profesor>> ProfWithDepButNoAsign()
    {
        return await _context.Set<Profesor>()
            .Include(e => e.Departamento)
            .Include(e => e.ProfesorP)
            .Include(e => e.Asignaturas)
            .Where(e => e.Departamento != null && e.Asignaturas.Count() == 0)
            .ToListAsync();
    }
}