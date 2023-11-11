using API.Helpers;
using API.Dtos;
using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;


namespace API.Controllers;
public class AsignaturaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _map;
    public AsignaturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _map = mapper;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Asignaturas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<AsignaturaDto>(dato);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<AsignaturaDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Asignaturas.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<AsignaturaDto>>(labs.registros);
        return new Pager<AsignaturaDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> GuardarCurso(AsignaturaDto param)
    {
        var dato = _map.Map<Asignatura>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Asignaturas.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Asignaturas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Asignaturas.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _map.Map<AsignaturaDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> Actualizar(AsignaturaDto param)
    {
        var dato = await _unitOfWork.Asignaturas.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Asignaturas.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpGet("GetTercerCurso")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult< IEnumerable<AsignaturaDto>>> GetTercerCurso(){
        var datos = await _unitOfWork.Asignaturas.GetFirstCuatrimestre();
        return _map.Map<List<AsignaturaDto>>(datos);
    }
    [HttpGet("GetByAlumnsGirlsThatMatIng")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult< IEnumerable<PersonaDto>>> GetByAlumnsGirlsThatMatIng(){
        var datos = await _unitOfWork.Asignaturas.GetByAlumnsGirlsThatMatIng();
        return _map.Map<List<PersonaDto>>(datos);
    }
    [HttpGet("GetByGrado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetByGrado(){
        var datos = await _unitOfWork.Asignaturas.GetByGrado();
        return _map.Map<List<AsignaturaDto>>(datos);
    }
    [HttpGet("GetWithoutProf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetWithoutProf(){
        var datos =  await _unitOfWork.Asignaturas.GetAsignWithoutProf();
        return _map.Map<List<AsignaturaDto>>(datos);
    }
}
