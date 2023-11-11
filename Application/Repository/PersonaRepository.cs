
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly APIContext _context;
    public PersonaRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public IEnumerable<Persona> AllSort(){
        var datos =  _context.Set<Persona>()
            .Where(e => e.Tipo == Tipo.alumno)
            .OrderBy(e => e.Apellido1)
            .ThenBy(e => e.Apellido2)
            .ThenBy(e => e.Nombre);
            return datos;
    }
    public IEnumerable<Persona> AllButNotNull(){
        return _context.Set<Persona>()
            .Where(e => e.Telefono != null);
    }
    public IEnumerable<Persona> AllButNotNullWithK(){
        return _context.Set<Persona>()
            .Where(e => e.Telefono != null && e.Nif.EndsWith("K"));
    }
    public IEnumerable<Persona> GetBeforeTwoThounsend(){
        return _context.Set<Persona>()
            .Where(e => e.Tipo == Tipo.alumno && e.FechaNacimiento.Year == 1999);
    }
    public async Task<IEnumerable<Persona>> GetByNif(){
        return await _context.Set<Persona>()
            .Include(e => e.CursoEscolares)
            .Include(e => e.Asignaturas)
            .ThenInclude(e => e.Profesor.ProfesorP)
            .Where(e => e.Nif == "26902806M")
            .ToListAsync();
    }
    
}
