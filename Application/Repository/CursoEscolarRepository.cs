
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
{
    private readonly APIContext _context;
    public CursoEscolarRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}
