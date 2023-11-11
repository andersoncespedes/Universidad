
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
    public async Task<IEnumerable<Profesor>> GetWithDept(){
        return await _context.Set<Profesor>()
        .Include(e => e.Departamento)
        .Include(e => e.ProfesorP)
        .OrderByDescending(e => e.ProfesorP.Nombre)
        .ThenBy(e => e.ProfesorP.Apellido1)
        .ThenBy(e => e.ProfesorP.Apellido2).ToListAsync();
    }
}