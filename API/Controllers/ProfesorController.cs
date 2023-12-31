using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;
using API.Helpers;
using Domain.Entities;


namespace API.Controllers;
public class ProfesorController : BaseApiController
{
     private IUnitOfWork _unitOfWork;
    private IMapper _map;
    public ProfesorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _map = mapper;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Profesores.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<ProfesorDto>(dato);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProfesorDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Profesores.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<ProfesorDto>>(labs.registros);
        return new Pager<ProfesorDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> GuardarCurso(ProfesorDto param)
    {
        var dato = _map.Map<Profesor>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Profesores.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Profesores.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Profesores.Remove(dato);
        await _unitOfWork.SaveAsync();
        return _map.Map<ProfesorDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> Actualizar(ProfesorDto param)
    {
        var dato = await _unitOfWork.Profesores.GetById(param.ProfesorP.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Profesores.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpGet("GetByProfWithDept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesoresWithDptDto>>> GetProfWithDept(){
        var datos = await _unitOfWork.Profesores.GetWithDept();
        return _map.Map<List<ProfesoresWithDptDto>>(datos);
    }
    [HttpGet("GetWithDepts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesoresWithDptDto>>> GetWithDepts()
    {
        var datos = await _unitOfWork.Profesores.GetAllWithDept();
        return _map.Map<List<ProfesoresWithDptDto>>(datos);
    }
    [HttpGet("GetWithNoDepts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<(IEnumerable<object>, IEnumerable<object>)>> GetWithNoDepts()
    {
        var datos = await _unitOfWork.Profesores.GetWithNoDept();
        return datos;
    }
    [HttpGet("GetWithNoAsignatures")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetWithNoAsign()
    {
        var datos = await _unitOfWork.Profesores.GetWithNoAsignatures();
        return _map.Map<List<PersonaDto>>(datos);
    }
    [HttpGet("GetWithNoAsignaturesCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetWithAssignCount()
    {
        var datos = await _unitOfWork.Profesores.GetWithAsignaturesCount();
        return _map.Map<List<PersonaDto>>(datos);
    }
    [HttpGet("GetProfWithNoDep")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetProfWithNoDepButNoAssign()
    {
        var datos = await _unitOfWork.Profesores.ProfWithDepButNoAsign();
        return _map.Map<List<PersonaDto>>(datos);
    }
    [HttpGet("GetProfWithNo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetProfWithNoDep()
    {
        var datos = await _unitOfWork.Profesores.GetProfWithoutDeps();
        return _map.Map<List<PersonaDto>>(datos);
    }
}
