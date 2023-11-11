
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
}
