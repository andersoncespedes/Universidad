
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
{
    private readonly APIContext _context;
    public CursoEscolarRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Persona>> GetStudentsDate(){
        return await _context.Set<CursoEscolar>()
            .Include(e => e.Personas.Where(e => e.Tipo == Tipo.alumno))
            .Where(e => e.AnyoInicio == 2018 && e.AnyoFin == 2019)
            .SelectMany(e => e.Personas)
            .ToListAsync();
    }
    public async Task<IEnumerable<CursoEscolar>> GetStudentsDateAndCount(){
        return await _context.Set<CursoEscolar>()
            .Include(e => e.Personas)
            .ToListAsync();
    }
}
