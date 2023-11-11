
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly APIContext _context;
    public GradoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Grado>> GradosWithCountAssign(){
        return await _context.Set<Grado>()
        .Include(e => e.Asignaturas)
        .OrderByDescending(e => e.Asignaturas.Count())
        .ToListAsync();
    }
    public async Task<IEnumerable<Grado>> GradosWithCountAssignWithMoreThan40(){
        return await _context.Set<Grado>()
        .Include(e => e.Asignaturas)
        .Where(e => e.Asignaturas.Count() > 40)
        .OrderByDescending(e => e.Asignaturas.Count())
        .ToListAsync();
    }
    public async Task<IEnumerable<Grado>> GradosWithAssignWithCredits(){
        return await _context.Set<Grado>()
        .Include(e => e.Asignaturas)
        .OrderByDescending(e => e.Asignaturas.Select(e => e.Creditos).Sum())
        .ToListAsync();
    }
}
