
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly APIContext _context;
    public GradoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}
