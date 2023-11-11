
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    private readonly APIContext _context;
    public AsignaturaRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Asignatura>> GetFirstCuatrimestre(){
        return await _context.Set<Asignatura>()
        .Include(e => e.Grado)
        .Where(e => e.Cuatrimestre == 1 && e.Curso == 3 && e.Grado.Id == 7)
        .ToListAsync()
        ;
    }
    public async Task<IEnumerable<Persona>> GetByAlumnsGirlsThatMatIng(){
        return await _context.Set<Asignatura>()
            .Include(e => e.Personas)
            .Include(e => e.Grado)
            .Where(e => e.Grado.Nombre  == "Grado en Ingeniería Informática (Plan 2015)")
            .SelectMany(e => e.Personas)
            .Where(e => e.Tipo == Tipo.alumno && e.Sexo == Sexo.M)
            .ToListAsync();
    }
    public async Task<IEnumerable<Asignatura>> GetByGrado(){
        return await _context.Set<Asignatura>()
            .Include(e => e.Grado)
            .Where(e => e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
            .ToListAsync();
    }
    
}
