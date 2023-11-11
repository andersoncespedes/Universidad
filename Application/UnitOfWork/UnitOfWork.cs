using Application.Repository;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IAsignatura _asignatura;
    private ICursoEscolar _cursoEscolares ;
    private IDepartamento _departamentos ;
    private IGrado _grados ;
    private IPersona _persona;
    private IProfesor _profesor;
    private readonly APIContext _context;
    public UnitOfWork(APIContext context){
        _context = context;
    }
    public ICursoEscolar CursoEscolares 
    {
        get {
            _cursoEscolares ??= new CursoEscolarRepository(_context);
            return _cursoEscolares;
        }
    }

    public IDepartamento Departamentos
    {
        get{
            _departamentos ??= new DepartamentoRepository(_context);
            return _departamentos;
        }
    }

    public IGrado Grados
    {
        get{
            _grados ??= new GradoRepository(_context);
            return _grados;
        }
    }

    public IPersona Personas 
    {
        get{
            _persona ??= new PersonaRepository(_context);
            return _persona;
        }
    }

    public IProfesor Profesores
    {
        get{
            _profesor ??= new ProfesorRepository(_context);
            return _profesor;
        }
    }

    public IAsignatura Asignaturas 
    {
        get{
            _asignatura ??= new AsignaturaRepository(_context);
            return _asignatura;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
